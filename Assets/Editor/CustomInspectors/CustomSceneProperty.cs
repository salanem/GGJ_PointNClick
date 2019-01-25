/****************************************
 * Copyright © Jan Schmitz 2018         *
 * Date: 12/29/2018 12:30:06 AM			*
 ****************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Scene))]
public class CustomSceneProperty : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        SerializedProperty scene = property.FindPropertyRelative("m_sceneObject");
        SerializedProperty scenePath = property.FindPropertyRelative("m_scenePath");
        SerializedProperty sceneName = property.FindPropertyRelative("m_sceneName");
        SerializedProperty buildIndex = property.FindPropertyRelative("m_buildIndex");
        Object newScene;

        EditorGUI.BeginChangeCheck();

        newScene = EditorGUI.ObjectField(position, scene.objectReferenceValue, typeof(SceneAsset), false);

        if (EditorGUI.EndChangeCheck())
        {
            if (newScene != null)
            {
                string path = AssetDatabase.GetAssetPath(newScene);
                bool inBuild = false;
                for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
                {
                    if (EditorBuildSettings.scenes[i].path == path)
                    {
                        buildIndex.intValue = i;
                        inBuild = true;
                        break;
                    }
                }
                if (!inBuild)
                {
                    Debug.LogError("Scene is not in the current build!");
                    scenePath.stringValue = "";
                    sceneName.stringValue = "";
                    buildIndex.intValue = -1;
                    scene.objectReferenceValue = null;
                    return;
                }
                scenePath.stringValue = path;
                scene.objectReferenceValue = newScene;
                sceneName.stringValue = path.Split('/').Last().Replace(".unity", "");
            }
            else
            {
                scenePath.stringValue = "";
                sceneName.stringValue = "";
                scene.objectReferenceValue = null;
                buildIndex.intValue = -1;
            }
        }
        EditorGUI.EndProperty();
    }
}
