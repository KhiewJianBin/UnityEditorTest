#if UNITY_EDITOR

using UnityEditor;

[CustomEditor(typeof(AEMEditorExample)), CanEditMultipleObjects]
public class AEMEditorExampleEditor : AEMEditor
{
    SerializedProperty propertyVar;

    protected override void OnEnable()
    {
        // To Modify
        ShowScriptHeader = false;
        Lock = true;

        ExcludeProperty.Add("variableName");

        propertyVar = serializedObject.FindProperty("property");
        propertyVar.floatValue = 123;
        serializedObject.ApplyModifiedProperties();

        base.OnEnable();
    }

    protected override void BeforeDefaultInspector()
    {
        /*Things to draw before default inspector*/
    }

    protected override void AfterDefaultInspector()
    {
        /*Things to draw after default inspector*/

        /*Get a Reference to the target script and do something*/
        AEMEditor t = target as AEMEditor;
    }
}
#endif 