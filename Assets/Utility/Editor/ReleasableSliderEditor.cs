using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ReleasableSlider))]
public class ReleasableSliderEditor : UnityEditor.UI.SliderEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUI.BeginChangeCheck();

        var p = serializedObject.FindProperty("onReleased");
        Debug.Assert(p != null, this);
        EditorGUILayout.PropertyField(p, true);

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}