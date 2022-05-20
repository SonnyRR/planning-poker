using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;

using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{
	// Support plugins are available for:
	//   - JetBrains ReSharper        https://nuke.build/resharper
	//   - JetBrains Rider            https://nuke.build/rider
	//   - Microsoft VisualStudio     https://nuke.build/visualstudio
	//   - Microsoft VSCode           https://nuke.build/vscode

	public static int Main() => Execute<Build>(x => x.Compile);

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

	[Solution] readonly Solution Solution;

#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable RCS1213 // Remove unused member declaration.
	[GitRepository] readonly GitRepository GitRepository;
#pragma warning restore RCS1213 // Remove unused member declaration.
#pragma warning restore IDE0051 // Remove unused private members

	[GitVersion(Framework = "net6.0")] readonly GitVersion GitVersion;

	AbsolutePath SourceDirectory => RootDirectory / "src";
	AbsolutePath TestsDirectory => RootDirectory / "tests";
	AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

	Target Clean => _ => _
		.Before(this.Restore)
		.Executes(() =>
		{
			this.SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
			this.TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
			EnsureCleanDirectory(this.ArtifactsDirectory);
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
		});

	Target CleanAutogenetedDtos => _ => _
		.Executes(() =>
		{
			DotNetMSBuild(s => s.AddTargets("CleanGenerated"));
		});

	Target GenerateDtos => _ => _
		.Executes(() =>
		{
			DotNetMSBuild(s => s.AddTargets("Mapster"));
		});
}
