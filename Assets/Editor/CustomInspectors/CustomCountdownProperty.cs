/****************************************
 * Copyright © Jan Schmitz 2018         *
 * Date: 12/30/2018 3:51:49 PM			*
 ****************************************/
 
using UnityEditor;

/**
 * \namespace TimeUtilities.Editor
 * \brief Contains editor class for the time utilities.
 */
namespace TimeUtilities.Editor
{
    [CustomPropertyDrawer(typeof(Countdown))]
    [CustomPropertyDrawer(typeof(RepeatingCountdown))]
    public class CustomCountdownProperty : PropertyDrawer
    {
        public override void OnGUI(UnityEngine.Rect position, SerializedProperty property, UnityEngine.GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            SerializedProperty time = property.FindPropertyRelative("m_time");
            EditorGUI.PropertyField(position, time);

            EditorGUI.EndProperty();
        }
    }
}