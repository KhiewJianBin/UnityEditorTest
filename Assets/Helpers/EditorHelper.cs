using UnityEditor;
using UnityEngine;

public static class EditorHelper
{
    public static void ShowList(SerializedProperty list, bool showListSize = true)
    {
        EditorGUILayout.PropertyField(list);
        EditorGUI.indentLevel += 1;
        if (list.isExpanded)
        {
            if (showListSize)
            {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
            }
            for (int i = 0; i < list.arraySize; i++)
            {
                EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
            }
        }
        EditorGUI.indentLevel -= 1;
    }
    public static void ShowDisabledList(SerializedProperty list, bool showListSize = true, bool disabled = true)
    {
        EditorGUI.BeginDisabledGroup(disabled);
        ShowList(list, showListSize);
        EditorGUI.EndDisabledGroup();
    }
    public static void DrawScriptField(this Editor editor)
    {
        SerializedProperty script = editor.serializedObject.FindProperty("m_Script");
        EditorGUILayout.ObjectField("Script", script.objectReferenceValue, typeof(MonoScript), false);
    }
    public static void DrawFakeSeparateLine()
    {
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
    }
}
