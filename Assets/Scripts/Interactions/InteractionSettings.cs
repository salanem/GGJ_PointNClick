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

    public Dialog[] FailResponses
    {
        get
        {
            return m_failResponses;
        }
    }

    public Dialog[] SuccessResponses
    {
        get
        {
            return m_successResponses;
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
    protected Dialog[] m_failResponses;
    [SerializeField]
    protected Dialog[] m_successResponses;
    [SerializeField]
    protected Animation m_successAnimation;
}
