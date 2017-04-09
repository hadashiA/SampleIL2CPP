using System.Linq;
using UnityEditor;
using UnityEngine;

public static class BuildCommand
{
    public static void Build()
    {
        var scenePaths = EditorBuildSettings.scenes.Select(s => s.path).ToArray();
        var errorMessage = BuildPipeline.BuildPlayer(
            scenePaths,
            "SampleIL2CPP",
            BuildTarget.Android,
            BuildOptions.Development | BuildOptions.AllowDebugging);

        if (!string.IsNullOrEmpty(errorMessage))
        {
            Debug.LogError(errorMessage);
            EditorApplication.Exit(1);
        }
    }
}
