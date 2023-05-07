using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
	public static int Main() => Execute<Build>(x => x.Compile);

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

	[Solution] readonly Solution Solution;

	[NuGetPackage("mapster.tool", "Mapster.Tool.dll", Framework = "net6.0")] readonly Tool Mapster;

	[GitRepository] readonly GitRepository GitRepository;

	[GitVersion(Framework = "net6.0", UpdateBuildNumber = true)] readonly GitVersion GitVersion;

	AbsolutePath SourceDirectory => RootDirectory / "src";
	AbsolutePath TestsDirectory => RootDirectory / "tests";
	AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
	AbsolutePath CoreAssemblyDirectory => this.SourceDirectory / "Core";
	AbsolutePath SharedKernelAssemblyDirectory => this.SourceDirectory / "SharedKernel";

	Target Clean => _ => _
		.Before(this.Restore)
		.Executes(() =>
		{
			this.SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(dir => dir.DeleteDirectory());
			this.TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(dir => dir.DeleteDirectory());
			this.ArtifactsDirectory.CreateOrCleanDirectory();
		});

	Target Restore => _ => _
		.Executes(() =>
		{
			DotNetRestore(s => s
				.SetProjectFile(this.Solution));
		});

	Target Compile => _ => _
		.DependsOn(this.Restore)
		.DependsOn(this.Clean)
		.Executes(() =>
		{
			DotNetBuild(s => s
				.SetProjectFile(this.Solution)
				.SetConfiguration(this.Configuration)
				.SetAssemblyVersion(this.GitVersion.AssemblySemVer)
				.SetFileVersion(this.GitVersion.AssemblySemFileVer)
				.SetInformationalVersion(this.GitVersion.InformationalVersion)
				.EnableNoRestore());

			Log.Information(this.GitVersion.MajorMinorPatch);
		});

	Target CleanAutogeneratedModels => _ => _
		.Executes(() =>
		{
			const string GENERATED_FILES_PATTERN = "**\\*.g.cs";

			foreach (var file in this.CoreAssemblyDirectory.GlobFiles(GENERATED_FILES_PATTERN)
				         .Union(this.SharedKernelAssemblyDirectory.GlobFiles(GENERATED_FILES_PATTERN)))
			{
				file.DeleteFile();
			}
		});

	[UsedImplicitly]
	Target CodeGenerateModels => _ => _
		.DependsOn(this.CleanAutogeneratedModels)
		.Executes(() =>
		{
			const string MAPPERS_NAMESPACE = "PlanningPoker.Core.Mapping";
			var assemblyToScan = this.CoreAssemblyDirectory / "bin" / "Debug" / "net6.0" / "PlanningPoker.Core.dll";
			var generatedFilesDir = this.CoreAssemblyDirectory / "Models" / "Generated";

			this.Mapster.Invoke(
				$"model -a {assemblyToScan} -o {generatedFilesDir} -n PlanningPoker.SharedKernel.Models.Generated");

			DotNetBuild(s => s
				.SetProcessWorkingDirectory(this.CoreAssemblyDirectory)
				.SetProjectFile("PlanningPoker.Core.csproj")
				.SetConfiguration(this.Configuration)
			);

			this.Mapster.Invoke(
				$"extension -a {assemblyToScan} -o {this.CoreAssemblyDirectory / "Mapping"} -n {MAPPERS_NAMESPACE}");
			this.Mapster.Invoke(
				$"mapper -a {assemblyToScan} -o {this.CoreAssemblyDirectory / "Mapping"} -n {MAPPERS_NAMESPACE}");

			CopyDirectoryRecursively(generatedFilesDir, this.SharedKernelAssemblyDirectory / "Models" / "Generated",
				DirectoryExistsPolicy.Merge);
			generatedFilesDir.DeleteDirectory();
		});
}
