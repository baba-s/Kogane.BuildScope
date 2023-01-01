# Kogane Build Scope

ビルド時に変更した設定をビルド後に元に戻せるクラス

## 使用例

```cs
using System.Linq;
using Kogane;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public static class Example
{
    [MenuItem( "Tools/Hoge" )]
    private static void Hoge()
    {
        const BuildTarget      target      = BuildTarget.Android;
        const BuildTargetGroup targetGroup = BuildTargetGroup.Android;

        using ( new SaveAssetsScope() )
        using ( new SetBuildAppBundleScope( targetGroup, true ) )
        using ( new SetScriptingDefineSymbolsForGroupScope( targetGroup, "ENABLE_RELEASE" ) )
        using ( new SetProductNameScope( "プロダクト名" ) )
        using ( new SetApplicationIdentifierScope( targetGroup, "com.hoge.fuga" ) )
        using ( new SetScriptingBackendScope( targetGroup, ScriptingImplementation.IL2CPP ) )
        using ( new SetIl2CppCompilerConfigurationScope( targetGroup, Il2CppCompilerConfiguration.Master ) )
        using ( new SetAndroidTargetArchitecturesScope( targetGroup, AndroidArchitecture.ARM64 ) )
        {
            var buildPlayerOptions = new BuildPlayerOptions
            {
                scenes           = EditorBuildSettings.scenes.Select( x => x.path ).ToArray(),
                locationPathName = "game.aab",
                targetGroup      = targetGroup,
                target           = target,
                options          = BuildOptions.None,
            };

            var buildReport = BuildPipeline.BuildPlayer( buildPlayerOptions );
            var isSuccess   = buildReport.summary.result == BuildResult.Succeeded;

            if ( !Application.isBatchMode || isSuccess ) return;

            EditorApplication.Exit( 1 );
        }
    }
}
```