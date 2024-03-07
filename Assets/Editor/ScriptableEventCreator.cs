using UnityEditor;
using UnityEngine;
using System.IO;

public class ScriptableEventCreator
{
    public static string className = string.Empty;
    public static string overloadTypeName = string.Empty;
    public static string folderPath = string.Empty;

    [MenuItem("Scriptables/Create Scriptable Event Script")]
    static void CreateInjectorScripts()
    {
        StringModalWindow window = EditorWindow.CreateInstance<StringModalWindow>();
        window.titleContent = new GUIContent("Create Scriptable Event Script");
        window.ShowModal();

        if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(overloadTypeName) || string.IsNullOrWhiteSpace(folderPath)) return;

        string scriptableEvent = @"using UnityEngine;

namespace Neisum.ScriptableEvents
{
    [CreateAssetMenu(fileName = " + '\u0022' + className + @"Event" + '\u0022' + ", menuName = " + '\u0022' + "ScriptableEvents/" + className + '\u0022' + @", order = 0 )]
    public class " + className + @"Event : BaseEvent<" + overloadTypeName + @"> { }
}";

        File.WriteAllText(Path.Combine(folderPath, className + "Event.cs"), scriptableEvent);
    }

    private class StringModalWindow : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Class name", GUILayout.Width(100));
            className = GUILayout.TextField(className, 50);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Overload type name", GUILayout.Width(100));
            overloadTypeName = GUILayout.TextField(overloadTypeName, 50);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Destination path", GUILayout.Width(100));
            folderPath = GUILayout.TextField(folderPath, 100);
            if (GUILayout.Button("Find", GUILayout.Width(50)))
                folderPath = Path.GetRelativePath(Directory.GetParent(Application.dataPath).FullName, EditorUtility.SaveFolderPanel("Create scripts paths", Application.dataPath, string.Empty));
            GUILayout.EndHorizontal();

            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(folderPath) || string.IsNullOrWhiteSpace(overloadTypeName)) return;
            GUILayout.Space(10);
            if (GUILayout.Button("Submit")) Close();

        }
    }
}
