using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class CustomWindowTest : EditorWindow
{
    [MenuItem("CustomWindow/WindowTest1")]
    static void Init()
    {
        CustomWindowTest window = (CustomWindowTest)EditorWindow.GetWindow(typeof(CustomWindowTest));
    }



    AnimBool m_ShowExtraFields;
    string m_String;
    Color m_Color = Color.white;
    int m_Number = 0;

    void OnEnable()
    {
        m_ShowExtraFields = new AnimBool(true);
        //m_ShowExtraFields.valueChanged == Repaint;
    }

    void OnGUI()
    {
        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", m_ShowExtraFields.target);

        //Extra block that can be toggled on and off.
        using (var group = new EditorGUILayout.FadeGroupScope(m_ShowExtraFields.faded))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PrefixLabel("Color");
                m_Color = EditorGUILayout.ColorField(m_Color);
                EditorGUILayout.PrefixLabel("Text");
                m_String = EditorGUILayout.TextField(m_String);
                EditorGUILayout.PrefixLabel("Number");
                m_Number = EditorGUILayout.IntSlider(m_Number, 0, 10);
                EditorGUI.indentLevel--;
            }
        }
    }
}