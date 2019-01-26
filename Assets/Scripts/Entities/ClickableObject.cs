using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ClickableObject : MonoBehaviour
{
    public string m_ObjectName;

    public InteractionSettings m_OpenSettings;
    public InteractionSettings m_CloseSettings;
    public InteractionSettings m_GiveSettings;
    public InteractionSettings m_PickUpSettings;
    public InteractionSettings m_LookAtSettings;
    public InteractionSettings m_TalkToSettings;
    public InteractionSettings m_PushSettings;
    public InteractionSettings m_PullSettings;
    public UseInteractionSettings m_UseSettings;

    protected virtual void OnMouseDown()
    {
        Debug.Log("MouseDown");
        switch (GameManager.Get.m_CurrentInteractionType)
        {
            case EInteractionType.NONE:
                break;
            case EInteractionType.OPEN:
                Respond(m_OpenSettings);
                break;
            case EInteractionType.CLOSE:
                Respond(m_CloseSettings);
                break;
            case EInteractionType.GIVE:
                Respond(m_GiveSettings);
                break;
            case EInteractionType.PICK_UP:
                Respond(m_PickUpSettings);
                if (m_PickUpSettings.IsPossible)
                {
                    if (this is PickableObject)
                    {
                        GameManager.Get.AddToInventory((PickableObject)this);
                    }
                }
                break;
            case EInteractionType.LOOK_AT:
                Respond(m_LookAtSettings);
                break;
            case EInteractionType.TALK_TO:
                Respond(m_TalkToSettings);
                break;
            case EInteractionType.PUSH:
                Respond(m_PushSettings);
                break;
            case EInteractionType.PULL:
                Respond(m_PullSettings);
                break;
            case EInteractionType.USE:
                Use(m_UseSettings);
                break;
            default:
                break;
        }
    }

    protected virtual void Respond(InteractionSettings _settings)
    {
        if (!_settings.IsPossible)
        {
            if (_settings.UseDefaultResponses)
            {
                TextBubbleManager.Get.DisplayTextBubble(GameManager.Get.m_DefaultFailedResponses.Random(),
                    GameManager.Get.m_DefaultTextTime);
            }
            else
            {
                if (_settings.FailResponses != null && _settings.FailResponses.Length > 0)
                {
                    TextBubbleManager.Get.DisplayTextBubble(_settings.FailResponses.Random(),
                        GameManager.Get.m_DefaultTextTime);
                }
            }
        }
        else
        {
            if (_settings.UseDefaultResponses)
            {
                TextBubbleManager.Get.DisplayTextBubble(GameManager.Get.m_DefaultSuccessResponses.Random(),
                    GameManager.Get.m_DefaultTextTime);
            }
            else
            {
                if (_settings.SuccessResponses != null && _settings.SuccessResponses.Length > 0)
                {
                    TextBubbleManager.Get.DisplayTextBubble(_settings.SuccessResponses.Random(),
                        GameManager.Get.m_DefaultTextTime);
                }
            }
            if (_settings.SuccessAnimation != null)
            {
                _settings.SuccessAnimation.Play();
            }
        }
    }
    protected virtual void Respond(InteractionSettings _settings, bool _isPossible)
    {
        if (!_isPossible)
        {
            if (_settings.UseDefaultResponses)
            {
                TextBubbleManager.Get.DisplayTextBubble(GameManager.Get.m_DefaultFailedResponses.Random(),
                    GameManager.Get.m_DefaultTextTime);
            }
            else
            {
                if (_settings.FailResponses != null && _settings.FailResponses.Length > 0)
                {
                    TextBubbleManager.Get.DisplayTextBubble(_settings.FailResponses.Random(),
                        GameManager.Get.m_DefaultTextTime);
                }
            }
        }
        else
        {
            if (_settings.UseDefaultResponses)
            {
                TextBubbleManager.Get.DisplayTextBubble(GameManager.Get.m_DefaultSuccessResponses.Random(),
                    GameManager.Get.m_DefaultTextTime);
            }
            else
            {
                if (_settings.SuccessResponses != null && _settings.SuccessResponses.Length > 0)
                {
                    TextBubbleManager.Get.DisplayTextBubble(_settings.SuccessResponses.Random(),
                        GameManager.Get.m_DefaultTextTime);
                }
            }
            if (_settings.SuccessAnimation != null)
            {
                _settings.SuccessAnimation.Play();
            }
        }
    }

    protected virtual void Use(UseInteractionSettings _settings)
    {
        if (!_settings.IsPossible)
        {
            Respond(_settings);
        }
        if (string.IsNullOrWhiteSpace(_settings.CanBeUsedWith) || GameManager.Get.CurrentInventoryItem.m_ObjectName
            == _settings.CanBeUsedWith)
        {
            Respond(_settings);

            GameManager.Get.CurrentInventoryItem.Used();
        }
        else
        {
            Respond(_settings, false);
        }
    }
}
