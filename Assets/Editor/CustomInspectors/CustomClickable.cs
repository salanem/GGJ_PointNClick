using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ClickableObject))]
public class CustomClickable : Editor
{
    private SerializedProperty m_objectName;

    private SerializedProperty m_openPossible;
    private SerializedProperty m_openUseDefault;
    private SerializedProperty m_openSuccessReponses;
    private SerializedProperty m_openFailedResponses;
    private SerializedProperty m_openAnimation;

    private SerializedProperty m_closePossible;
    private SerializedProperty m_closeUseDefault;
    private SerializedProperty m_closeSuccessReponses;
    private SerializedProperty m_closeFailedResponses;
    private SerializedProperty m_closeAnimation;

    private SerializedProperty m_givePossible;
    private SerializedProperty m_giveUseDefault;
    private SerializedProperty m_giveSuccessReponses;
    private SerializedProperty m_giveFailedResponses;
    private SerializedProperty m_giveAnimation;

    private SerializedProperty m_pickUpPossible;
    private SerializedProperty m_pickUpUseDefault;
    private SerializedProperty m_pickUpSuccessReponses;
    private SerializedProperty m_pickUpFailedResponses;
    private SerializedProperty m_pickUpAnimation;

    private SerializedProperty m_lookAtPossible;
    private SerializedProperty m_lookAtUseDefault;
    private SerializedProperty m_lookAtSuccessReponses;
    private SerializedProperty m_lookAtFailedResponses;
    private SerializedProperty m_lookAtAnimation;

    private SerializedProperty m_talkToPossible;
    private SerializedProperty m_talkToUseDefault;
    private SerializedProperty m_talkToSuccessReponses;
    private SerializedProperty m_talkToFailedResponses;
    private SerializedProperty m_talkToAnimation;

    private SerializedProperty m_pushPossible;
    private SerializedProperty m_pushUseDefault;
    private SerializedProperty m_pushSuccessReponses;
    private SerializedProperty m_pushFailedResponses;
    private SerializedProperty m_pushAnimation;

    private SerializedProperty m_pullPossible;
    private SerializedProperty m_pullUseDefault;
    private SerializedProperty m_pullSuccessReponses;
    private SerializedProperty m_pullFailedResponses;
    private SerializedProperty m_pullAnimation;

    private SerializedProperty m_usePossible;
    private SerializedProperty m_useUseDefault;
    private SerializedProperty m_useSuccessReponses;
    private SerializedProperty m_useFailedResponses;
    private SerializedProperty m_useAnimation;
    private SerializedProperty m_canBeUsedWith;

    protected virtual void OnEnable()
    {
        m_objectName = serializedObject.FindProperty("m_ObjectName");

        m_openPossible = serializedObject.FindProperty("m_CanBeOpend");
        m_openUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForOpen");
        m_openSuccessReponses = serializedObject.FindProperty("m_OpenSuccessResponses");
        m_openFailedResponses = serializedObject.FindProperty("m_OpenFailedResponses");
        m_openAnimation = serializedObject.FindProperty("m_OpenAnimation");

        m_closePossible = serializedObject.FindProperty("m_CanBeClosed");
        m_closeUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForClose");
        m_closeSuccessReponses = serializedObject.FindProperty("m_CloseSuccessResponses");
        m_closeFailedResponses = serializedObject.FindProperty("m_CloseFailedResponses");
        m_closeAnimation = serializedObject.FindProperty("m_CloseAnimation");

        m_givePossible = serializedObject.FindProperty("m_CanBeGiven");
        m_giveUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForGive");
        m_giveSuccessReponses = serializedObject.FindProperty("m_GiveSuccessResponses");
        m_giveFailedResponses = serializedObject.FindProperty("m_GiveFailedResponses");
        m_giveAnimation = serializedObject.FindProperty("m_GiveAnimation");

        m_pickUpPossible = serializedObject.FindProperty("m_CanBePickedUp");
        m_pickUpUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForPickUp");
        m_pickUpSuccessReponses = serializedObject.FindProperty("m_PickUpSuccessResponses");
        m_pickUpFailedResponses = serializedObject.FindProperty("m_PickUpFailedResponses");
        m_pickUpAnimation = serializedObject.FindProperty("m_PickUpAnimation");

        m_lookAtPossible = serializedObject.FindProperty("m_CanBeLookedAt");
        m_lookAtUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForLookAt");
        m_lookAtSuccessReponses = serializedObject.FindProperty("m_LookAtSuccessResponses");
        m_lookAtFailedResponses = serializedObject.FindProperty("m_LookAtFailedResponses");
        m_lookAtAnimation = serializedObject.FindProperty("m_LookAtAnimation");

        m_talkToPossible = serializedObject.FindProperty("m_CanBeTalkedTo");
        m_talkToUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForTalkTo");
        m_talkToSuccessReponses = serializedObject.FindProperty("m_TalkToSuccessResponses");
        m_talkToFailedResponses = serializedObject.FindProperty("m_TalkToFailedResponses");
        m_talkToAnimation = serializedObject.FindProperty("m_TalkToAnimation");

        m_pushPossible = serializedObject.FindProperty("m_CanBePushed");
        m_pushUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForPush");
        m_pushSuccessReponses = serializedObject.FindProperty("m_PushSuccessResponses");
        m_pushFailedResponses = serializedObject.FindProperty("m_PushFailedResponses");
        m_pushAnimation = serializedObject.FindProperty("m_PushAnimation");

        m_pullPossible = serializedObject.FindProperty("m_CanBePulled");
        m_pullUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForPull");
        m_pullSuccessReponses = serializedObject.FindProperty("m_PullSuccessResponses");
        m_pullFailedResponses = serializedObject.FindProperty("m_PullFailedResponses");
        m_pullAnimation = serializedObject.FindProperty("m_PullAnimation");

        m_usePossible = serializedObject.FindProperty("m_CanBeUsed");
        m_useUseDefault = serializedObject.FindProperty("m_UseDefaultResponsesForUse");
        m_useSuccessReponses = serializedObject.FindProperty("m_UseSuccessResponses");
        m_useFailedResponses = serializedObject.FindProperty("m_UseFailedResponses");
        m_useAnimation = serializedObject.FindProperty("m_UseAnimation");
        m_canBeUsedWith = serializedObject.FindProperty("m_CanBeUsedWith");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_objectName);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Open", EditorStyles.boldLabel);
        DisplayGroup(m_openPossible, m_openUseDefault, m_openSuccessReponses, m_openFailedResponses, m_openAnimation);
        EditorGUILayout.LabelField("Close", EditorStyles.boldLabel);
        DisplayGroup(m_closePossible, m_closeUseDefault, m_closeSuccessReponses, m_closeFailedResponses, m_closeAnimation);
        EditorGUILayout.LabelField("Give", EditorStyles.boldLabel);

        DisplayGroup(m_givePossible, m_giveUseDefault, m_giveSuccessReponses, m_giveFailedResponses, m_giveAnimation);
        EditorGUILayout.LabelField("PickUp", EditorStyles.boldLabel);
        DisplayGroup(m_pickUpPossible, m_pickUpUseDefault, m_pickUpSuccessReponses, m_pickUpFailedResponses, m_pickUpAnimation);
        EditorGUILayout.LabelField("LookAt", EditorStyles.boldLabel);
        DisplayGroup(m_lookAtPossible, m_lookAtUseDefault, m_lookAtSuccessReponses, m_lookAtFailedResponses, m_lookAtAnimation);
        EditorGUILayout.LabelField("TalkTo", EditorStyles.boldLabel);

        DisplayGroup(m_talkToPossible, m_talkToUseDefault, m_talkToSuccessReponses, m_talkToFailedResponses, m_talkToAnimation);
        EditorGUILayout.LabelField("Push", EditorStyles.boldLabel);
        DisplayGroup(m_pushPossible, m_pushUseDefault, m_pushSuccessReponses, m_pushFailedResponses, m_pushAnimation);
        EditorGUILayout.LabelField("Pull", EditorStyles.boldLabel);
        DisplayGroup(m_pullPossible, m_pullUseDefault, m_pullSuccessReponses, m_pullFailedResponses, m_pullAnimation);
        EditorGUILayout.LabelField("Use", EditorStyles.boldLabel);
        DisplayGroup(m_usePossible, m_useUseDefault, m_useSuccessReponses, m_useFailedResponses, m_useAnimation, m_canBeUsedWith);

        serializedObject.ApplyModifiedProperties();
    }

    private void DisplayGroup(SerializedProperty _possible, SerializedProperty _default, 
        SerializedProperty _success, SerializedProperty _fail, SerializedProperty _animation)
    {
        EditorGUILayout.PropertyField(_possible);
        if (_possible.boolValue)
        {
            EditorGUILayout.PropertyField(_animation);
        }
        EditorGUILayout.PropertyField(_default);
        if (!_default.boolValue)
        {
            EditorGUILayout.PropertyField(_success, true);
            EditorGUILayout.PropertyField(_fail, true);
        }
    }

    private void DisplayGroup(SerializedProperty _possible, SerializedProperty _default,
       SerializedProperty _success, SerializedProperty _fail, SerializedProperty _animation,
       SerializedProperty _useWith)
    {
        EditorGUILayout.PropertyField(_possible);
        if (_possible.boolValue)
        {
            EditorGUILayout.PropertyField(_animation);
            EditorGUILayout.PropertyField(_useWith);
        }
        EditorGUILayout.PropertyField(_default);
        if (!_default.boolValue)
        {
            EditorGUILayout.PropertyField(_success, true);
            EditorGUILayout.PropertyField(_fail, true);
        }
    }
}
