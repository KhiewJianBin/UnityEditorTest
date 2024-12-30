using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

/// <summary>
/// Simple Example of CustomWindow EditorWindow
/// </summary>
public class CustomWindowTemplate : EditorWindow
{
    [MenuItem("CustomWindow/CustomWindowTemplate")]
    static void Init()
    {
        CustomWindowTemplate window = (CustomWindowTemplate)GetWindow(typeof(CustomWindowTemplate));
    }

    AnimBool showExtraFields = new AnimBool(true);
    string text = string.Empty;
    Color color = Color.white;
    int number = 0;

    void OnGUI()
    {
        showExtraFields.target = EditorGUILayout.ToggleLeft("Show Extra Fields", showExtraFields.target);

        using (var group = new EditorGUILayout.FadeGroupScope(showExtraFields.faded))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.PrefixLabel("Color");
                color = EditorGUILayout.ColorField(color);

                EditorGUILayout.PrefixLabel("Text");
                text = EditorGUILayout.TextField(text);

                EditorGUILayout.PrefixLabel("Number");
                number = EditorGUILayout.IntSlider(number, 0, 10);

                EditorGUI.indentLevel--;
            }
        }
    }
}