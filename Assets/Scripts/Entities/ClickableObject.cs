using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ClickableObject : MonoBehaviour
{
    public string m_ObjectName;

    public bool m_CanBeOpend;
    public bool m_UseDefaultResponsesForOpen = true;
    public string[] m_OpenFailedResponses;
    public string[] m_OpenSuccessResponses;
    public Animation m_OpenAnimation;

    public bool m_CanBeClosed;
    public bool m_UseDefaultResponsesForClose = true;
    public string[] m_CloseFailedResponses;
    public string[] m_CloseSuccessResponses;
    public Animation m_CloseAnimation;

    public bool m_CanBeGiven;
    public bool m_UseDefaultResponsesForGive = true;
    public string[] m_GiveFailedResponses;
    public string[] m_GiveSuccessResponses;
    public Animation m_GiveAnimation;

    public bool m_CanBePickedUp;
    public bool m_UseDefaultResponsesForPickUp = true;
    public string[] m_PickUpFailedResponses;
    public string[] m_PickUpSuccessResponses;
    public Animation m_PickUpAnimation;

    public bool m_CanBeLookedAt;
    public bool m_UseDefaultResponsesForLookAt = true;
    public string[] m_LookAtFailedResponses;
    public string[] m_LookAtSuccessResponses;
    public Animation m_LookAtAnimation;

    public bool m_CanBeTalkedTo;
    public bool m_UseDefaultResponsesForTalkTo = true;
    public string[] m_TalkToFailedResponses;
    public string[] m_TalkToSuccessResponses;
    public Animation m_TalkToAnimation;

    public bool m_CanBePushed;
    public bool m_UseDefaultResponsesForPush = true;
    public string[] m_PushFailedResponses;
    public string[] m_PushSuccessResponses;
    public Animation m_PushAnimation;

    public bool m_CanBePulled;
    public bool m_UseDefaultResponsesForPull = true;
    public string[] m_PullFailedResponses;
    public string[] m_PullSuccessResponses;
    public Animation m_PullAnimation;

    public bool m_CanBeUsed;
    public bool m_UseDefaultResponsesForUse = true;
    public string m_CanBeUsedWith;
    public string[] m_UseFailedResponses;
    public string[] m_UseSuccessResponses;
    public Animation m_UseAnimation;

    protected virtual void OnMouseDown()
    {
        Debug.Log("MouseDown");
        switch (GameManager.Get.m_CurrentInteractionType)
        {
            case EInteractionType.NONE:
                break;
            case EInteractionType.OPEN:
                Respond(m_CanBeOpend, m_UseDefaultResponsesForOpen,
                    m_OpenSuccessResponses, m_OpenFailedResponses, m_OpenAnimation);
                break;
            case EInteractionType.CLOSE:
                Respond(m_CanBeClosed, m_UseDefaultResponsesForClose,
                    m_CloseSuccessResponses, m_CloseFailedResponses, m_CloseAnimation);
                break;
            case EInteractionType.GIVE:
                Respond(m_CanBeGiven, m_UseDefaultResponsesForGive,
                    m_GiveSuccessResponses, m_GiveFailedResponses, m_GiveAnimation);
                break;
            case EInteractionType.PICK_UP:
                Respond(m_CanBePickedUp, m_UseDefaultResponsesForPickUp,
                    m_PickUpSuccessResponses, m_PickUpFailedResponses, m_PickUpAnimation);
                break;
            case EInteractionType.LOOK_AT:
                Respond(m_CanBeLookedAt, m_UseDefaultResponsesForLookAt,
                  m_LookAtSuccessResponses, m_LookAtFailedResponses, m_LookAtAnimation);
                break;
            case EInteractionType.TALK_TO:
                Respond(m_CanBeTalkedTo, m_UseDefaultResponsesForTalkTo,
                  m_TalkToSuccessResponses, m_TalkToFailedResponses, m_TalkToAnimation);
                break;
            case EInteractionType.PUSH:
                Respond(m_CanBePushed, m_UseDefaultResponsesForPush,
                  m_PushSuccessResponses, m_PushFailedResponses, m_PushAnimation);
                break;
            case EInteractionType.PULL:
                Respond(m_CanBePulled, m_UseDefaultResponsesForPull,
                  m_PullSuccessResponses, m_PullFailedResponses, m_PullAnimation);
                break;
            case EInteractionType.USE:
                if (!m_CanBeUsed)
                {
                    Respond(m_CanBeUsed, m_UseDefaultResponsesForUse,
                     m_UseSuccessResponses, m_UseFailedResponses, m_UseAnimation);
                    break;
                }
                if (GameManager.Get.CurrentInventoryItem.m_ObjectName
                    == m_CanBeUsedWith)
                {
                    Respond(true, m_UseDefaultResponsesForUse,
                      m_UseSuccessResponses, m_UseFailedResponses, m_UseAnimation);

                    GameManager.Get.CurrentInventoryItem.Used();
                }
                else
                {
                    Respond(false, m_UseDefaultResponsesForUse,
                     m_UseSuccessResponses, m_UseFailedResponses, m_UseAnimation);
                }
                break;
            default:
                break;
        }
    }

    protected virtual void Respond(bool _isPossible, bool _defaultResponse,
        string[] _successResponses, string[] _failResponses, Animation _successAnimation)
    {
        if (!_isPossible)
        {
            if (_defaultResponse)
            {
                TextBubbleManager.Get.DisplayTextBubble(GameManager.Get.m_DefaultFailedResponses.Random(),
                    GameManager.Get.m_DefaultTextTime);
            }
            else
            {
                if (_failResponses != null && _failResponses.Length > 0)
                {
                    TextBubbleManager.Get.DisplayTextBubble(_failResponses.Random(),
                        GameManager.Get.m_DefaultTextTime);
                }
            }
        }
        else
        {
            if (_defaultResponse)
            {
                TextBubbleManager.Get.DisplayTextBubble(GameManager.Get.m_DefaultSuccessResponses.Random(),
                    GameManager.Get.m_DefaultTextTime);
            }
            else
            {
                if (_successResponses != null && _successResponses.Length > 0)
                {
                    TextBubbleManager.Get.DisplayTextBubble(_successResponses.Random(),
                        GameManager.Get.m_DefaultTextTime);
                }
            }
            if (_successAnimation != null)
            {
                _successAnimation.Play();
            }
        }
    }


}
