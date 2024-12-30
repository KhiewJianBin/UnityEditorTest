#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Wrapper to add a few extra stuff
/// Show or Hide Script Header
/// Lock Script
/// Exclude Certain Property
/// </summary>
public abstract class AEMEditor : Editor
{
    /// <summary>
    /// Whether or not to show the script field header
    /// </summary>
    public bool ShowScriptHeader = true;

    /// <summary>
    /// Used to allow or disallow the editing the inspector 
    /// A global static var
    /// </summary>
    public static bool Lock = false;

    /// <summary>
    /// List of properties to be excluded from drawing in the inspector
    /// </summary>
    protected List<string> ExcludeProperty = new List<string>();

    protected string commandName;

    public override void OnInspectorGUI()
    {
        //the current event type the gui is running right now
        commandName = Event.current.commandName;

        //Call the Update to all serialized object that appears in inspector
        serializedObject.Update();

        EditorGUILayout.Separator();

        //Locks the Inspector for editing
        Lock = EditorGUILayout.ToggleLeft("Lock", Lock);
        GUI.enabled = !Lock;

        //Any GUI to draw here before default inspector
        BeforeDefaultInspector();

        //Main GUI drawing to excluded any property added into ExcludeProperty<string>
        DrawPropertiesExcluding(serializedObject, ExcludeProperty.ToArray());

        //Any GUI to draw here after default inspector
        AfterDefaultInspector();

        //Apply property modifications. Unity docs not explained clearly
        serializedObject.ApplyModifiedProperties();
    }
    protected virtual void OnEnable()
    {
        if (!ShowScriptHeader)
        {
            ExcludeProperty.Add("m_script");
        }
    }
    protected virtual void BeforeDefaultInspector() { }
    protected virtual void AfterDefaultInspector() { }
}
#endif