using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ClickableObject : MonoBehaviour
{
    public string m_ObjectName;
    public bool m_InitalActive;

    public InteractionSettings m_OpenSettings;
    public InteractionSettings m_CloseSettings;
    public InteractionSettings m_GiveSettings;
    public InteractionSettings m_PickUpSettings;
    public InteractionSettings m_LookAtSettings;
    public InteractionSettings m_TalkToSettings;
    public InteractionSettings m_PushSettings;
    public InteractionSettings m_PullSettings;
    public UseInteractionSettings m_UseSettings;

    protected virtual void OnMouseEnter()
    {
        UIManager.Get.DisplayHoverItem(this);
    }

    protected virtual void OnMouseExit()
    {
        UIManager.Get.DisplayHoverItem(null);
    }

    protected virtual void OnMouseDown()
    {
        Interact();
    }

    public virtual void Interact()
    {
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
                ResponseManager.Get.ShowResponse(GameManager.Get.m_DefaultFailedResponse);
            }
            else
            {
                if (_settings.FailResponse != null && _settings.FailResponse.
                    m_PossibleDialogs.Length > 0)
                {
                    ResponseManager.Get.ShowResponse(_settings.FailResponse);
                }
            }
        }
        else
        {
            if (_settings.UseDefaultResponses)
            {
                ResponseManager.Get.ShowResponse(GameManager.Get.m_DefaultSuccessResponse);

            }
            else
            {
                if (_settings.SuccessResponse != null && _settings.SuccessResponse
                    .m_PossibleDialogs.Length > 0)
                {
                    ResponseManager.Get.ShowResponse(_settings.SuccessResponse);
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
                ResponseManager.Get.ShowResponse(GameManager.Get.m_DefaultFailedResponse);
            }
            else
            {
                if (_settings.FailResponse != null && _settings.FailResponse
                    .m_PossibleDialogs.Length > 0)
                {
                    ResponseManager.Get.ShowResponse(_settings.FailResponse);
                }
            }
        }
        else
        {
            if (_settings.UseDefaultResponses)
            {
                ResponseManager.Get.ShowResponse(GameManager.Get.m_DefaultSuccessResponse);
            }
            else
            {
                if (_settings.SuccessResponse != null && _settings.SuccessResponse
                    .m_PossibleDialogs.Length > 0)
                {
                    ResponseManager.Get.ShowResponse(_settings.SuccessResponse);
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
