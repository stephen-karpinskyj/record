using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(MultiImageButton))]
public class MultiImageButtonEditor : UnityEditor.UI.ButtonEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var b = (MultiImageButton)target;
        if (b.transition == Selectable.Transition.ColorTint)
        {
            EditorGUI.BeginChangeCheck();

            var p = serializedObject.FindProperty("additionalTargetGraphics");
            Debug.Assert(p != null, this);
            EditorGUILayout.PropertyField(p, true);

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}