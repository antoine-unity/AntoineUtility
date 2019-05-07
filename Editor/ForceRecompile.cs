using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace AntoineUtility
{
    internal static class ForceRecompile
    {
        [MenuItem("Utility/Recompile"), Shortcut("Recompile", KeyCode.K, ShortcutModifiers.Action)]
        static void TriggerForceRecompile()
        {
            var targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            var previous = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, "Test");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, previous);
        }
    }
}