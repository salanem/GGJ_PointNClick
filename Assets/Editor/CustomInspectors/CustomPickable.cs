using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PickableObject))]
public class CustomPickable : CustomClickable
{
    private SerializedProperty m_sprite;
    private SerializedProperty m_useCount;

    protected override void OnEnable()
    {
        m_sprite = serializedObject.FindProperty("m_InventorySprite");
        m_useCount = serializedObject.FindProperty("m_Uses");

        base.OnEnable();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(m_sprite);
        EditorGUILayout.PropertyField(m_useCount);
        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}
