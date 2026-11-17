using DG.Tweening.Core;
using UnityEditor;
using UnityEngine;

namespace DOTweenUPM.Editor
{
    internal static class DOTweenPackageSettings
    {
        private const string SettingsPath = "Assets/Resources/DOTweenSettings.asset";

        [MenuItem("Tools/Demigiant/DOTween Settings")]
        private static void OpenSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<DOTweenSettings>(SettingsPath);
            if (settings == null)
            {
                // An existing asset of another type must never be overwritten.
                if (AssetDatabase.LoadMainAssetAtPath(SettingsPath) != null)
                {
                    Debug.LogError("Cannot create DOTween settings: " + SettingsPath + " is already in use.");
                    return;
                }

                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                    AssetDatabase.CreateFolder("Assets", "Resources");

                settings = ScriptableObject.CreateInstance<DOTweenSettings>();
                AssetDatabase.CreateAsset(settings, SettingsPath);
                AssetDatabase.SaveAssets();
            }

            Selection.activeObject = settings;
            EditorGUIUtility.PingObject(settings);
        }
    }

    [CustomEditor(typeof(DOTweenSettings))]
    internal sealed class DOTweenPackageSettingsInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            // Module availability is controlled by compilation symbols, not these
            // legacy Asset Store setup fields. UPM supplies its own assemblies.
            DrawPropertiesExcluding(serializedObject, "m_Script", "modules", "createASMDEF",
                "storeSettingsLocation", "showPreviewPanel", "showPlayingTweens", "showPausedTweens");
            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox(
                "Modules are configured with Scripting Define Symbols in Player Settings. " +
                "See the package README for available symbols.", MessageType.Info);
        }
    }
}
