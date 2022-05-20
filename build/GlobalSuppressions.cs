// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Bug", "S3903:Types should be defined in named namespaces", Justification = "Namespaces should not be required in the NUKE build project.", Scope = "module")]
[assembly: SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification = "Namespaces should not be required in the NUKE build project.", Scope = "module")]
[assembly: SuppressMessage("Roslynator", "RCS1110:Declare type inside namespace.", Justification = "Namespaces should not be required in the NUKE build project.", Scope = "module")]
[assembly: SuppressMessage("Critical Code Smell", "S2223:Non-constant static fields should not be visible", Justification = "Not required in the NUKE build project.", Scope = "module")]
[assembly: SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible", Justification = "Not required in the NUKE build project.", Scope = "module")]
[assembly: SuppressMessage("Minor Code Smell", "S1104:Fields should not have public accessibility", Justification = "Not required in the NUKE build project.", Scope = "module")]
[assembly: SuppressMessage("Style", "IDE0053:Use expression body for lambda expressions", Justification = "Not required in the NUKE build project.", Scope = "module")]
[assembly: SuppressMessage("Major Code Smell", "S1144:Unused private types or members should be removed", Justification = "Not required in the NUKE build project.", Scope = "module")]
