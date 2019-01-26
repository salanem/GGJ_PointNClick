using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interaction", menuName = "Interaction/New Interaction")]
public class InteractionSettings : ScriptableObject
{
    public bool IsPossible
    {
        get
        {
            return m_isPossible;
        }
    }

    public bool UseDefaultResponses
    {
        get
        {
            return m_useDefaultResponses;
        }
    }

    public Response FailResponse
    {
        get
        {
            return m_failResponse;
        }
    }

    public Response SuccessResponse
    {
        get
        {
            return m_successResponse;
        }
    }

    public Animation SuccessAnimation
    {
        get
        {
            return m_successAnimation;
        }
    }

    [SerializeField]
    protected bool m_isPossible;
    [SerializeField]
    protected bool m_useDefaultResponses;
    [SerializeField]
    protected Response m_failResponse;
    [SerializeField]
    protected Response m_successResponse;
    [SerializeField]
    protected Animation m_successAnimation;
}
