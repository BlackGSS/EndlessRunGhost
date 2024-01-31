using UnityEditor;
using UnityEngine;
using System.IO;

namespace Neisum.ScriptableUpdaters
{
    public class ScriptableCreator
    {
        public static string className = string.Empty;
        public static string folderPath = string.Empty;

        [MenuItem("Scriptables/Create Scriptable Updatable")]
        static void CreateInjectorScripts()
        {
            StringModalWindow window = EditorWindow.CreateInstance<StringModalWindow>();
            window.titleContent = new GUIContent("Create Scriptable Scripts");
            window.ShowModal();

            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(folderPath)) return;

            //             string injectionCaller = @"using UnityEngine;

            // namespace Neisum.CodeInjection
            // {
            //     public class " + className + @"InjectionCaller : InstantiableScriptable<" + className + @"> { }
            // }";

            //             File.WriteAllText(Path.Combine(folderPath, className + "InjectionCaller.cs"), injectionCaller);

            //             string injectionListeners = @"using UnityEngine;

            // namespace Adruian.CodeInjection
            // {
            //     public class " + className + @"InjectionListeners : InjectionListeners<" + className + @"> { }
            // }";

            //             File.WriteAllText(Path.Combine(folderPath, className + "InjectionListeners.cs"), injectionListeners);

            string scriptableUpdater = @"using UnityEngine;

            namespace Neisum.ScriptableUpdaters
            {
                [CreateAssetMenu(fileName = " + '\u0022' + className + "Updater" + '\u0022' + ", menuName = " + '\u0022' + "ScriptableUpdaters/" + className + "Updater" + '\u0022' + @", order = 0)]
                public class " + className + "Updater : ScriptableUpdater<" + className + @"> { }
            }";

            File.WriteAllText(Path.Combine(folderPath, className + "Updater.cs"), scriptableUpdater);

            // string scriptableUpdater = @"using UnityEngine;

            // namespace Neisum.ScriptableUpdaters
            // {
            //     [CreateAssetMenu(fileName = " + '\u0022' + className + "Updater" + '\u0022' + ", menuName = " + '\u0022' + "ScriptableUpdaters/" + className + "Updater" + '\u0022' + @", order = 0)]
            //     public class " + className + "Updater : ScriptableUpdater<" + className + @"> { }
            // }";

            // File.WriteAllText(Path.Combine(folderPath, className + "Updater.cs"), scriptableUpdater);

            // ScriptableObject scriptable = AssetDatabase.LoadAssetAtPath(folderPath, typeof(ScriptableObject));
            // ScriptableUpdater<className> scriptable = AssetDatabase.LoadAssetAtPath(folderPath, typeof(ScriptableUpdater<className>));
        }

        private class StringModalWindow : EditorWindow
        {
            private void OnGUI()
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Scriptable name", GUILayout.Width(100));
                className = GUILayout.TextField(className, 50);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("Destination path", GUILayout.Width(100));
                folderPath = GUILayout.TextField(folderPath, 100);
                if (GUILayout.Button("Find", GUILayout.Width(50)))
                    folderPath = Path.GetRelativePath(Directory.GetParent(Application.dataPath).FullName, EditorUtility.SaveFolderPanel("Create scripts paths", Application.dataPath, string.Empty));
                GUILayout.EndHorizontal();

                if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(folderPath)) return;
                GUILayout.Space(10);
                if (GUILayout.Button("Submit")) Close();
            }
        }
    }
}