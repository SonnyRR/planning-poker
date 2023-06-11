using JetBrains.Annotations;

public static class Environments
{
    public static readonly string Development = "Development";

    [UsedImplicitly] public static readonly string Staging = "Staging";

    [UsedImplicitly] public static readonly string Production = "Production";
}