using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class Interaction : MonoBehaviour
    {
        public EInteractionType InteractionType
        {
            get
            {
                return m_interactionType;
            }
        }

        public InteractionSettings InteractionSettings
        {
            get
            {
                return m_settings;
            }
        }

        [SerializeField]
        protected EInteractionType m_interactionType;
        [SerializeField]
        protected InteractionSettings m_settings;
        protected Dictionary<Response, List<Dialog>> m_dialogsLeft = new Dictionary<Response, List<Dialog>>();
        protected Coroutine m_playAllCoroutine;

        protected virtual void Start()
        {
            GetComponent<ClickableObject>().AddInteraction(this);
        }

        public virtual void Interact()
        {
            DisplayResponds();
        }

        protected virtual void DisplayResponds()
        {
            if (!m_settings.IsPossible)
            {
                if (m_settings.UseDefaultResponses)
                {
                    ShowResponse(GameManager.Get.m_DefaultFailedResponse);
                }
                else
                {
                    if (m_settings.FailResponse != null && m_settings.FailResponse.
                        m_PossibleDialogs.Length > 0)
                    {
                        ShowResponse(m_settings.FailResponse);
                    }
                }
            }
            else
            {
                if (m_settings.UseDefaultResponses)
                {
                    ShowResponse(GameManager.Get.m_DefaultSuccessResponse);

                }
                else
                {
                    if (m_settings.SuccessResponse != null && m_settings.SuccessResponse
                        .m_PossibleDialogs.Length > 0)
                    {
                        ShowResponse(m_settings.SuccessResponse);
                    }
                }
                if (m_settings.SuccessAnimation != null)
                {
                    m_settings.SuccessAnimation.Play();
                }
            }
        }

        protected void ShowResponse(Response _response)
        {
            if (!m_dialogsLeft.ContainsKey(_response))
            {
                m_dialogsLeft.Add(_response, new List<Dialog>(_response.m_PossibleDialogs));
            }
            if (m_dialogsLeft[_response].Count == 0)
            {
                if (_response.m_RepeatLast)
                {
                    DialogManager.Get.PlayDialog(_response.m_PossibleDialogs.Last());
                    return;
                }
                if (_response.m_RepeatWhole)
                {
                    m_dialogsLeft[_response] = new List<Dialog>(_response.m_PossibleDialogs);
                }
            }
            if (m_playAllCoroutine != null)
            {
                StopCoroutine(m_playAllCoroutine);
            }
            if (_response.m_PlayAll)
            {
                DialogManager.Get.StopDialog();
                m_playAllCoroutine = StartCoroutine(PlayAll(_response));
            }
            else
            {
                PlayOneDialog(_response);
            }
        }

        protected void PlayOneDialog(Response _response)
        {
            List<Dialog> dialogsLeft = m_dialogsLeft[_response];
            if (dialogsLeft.Count == 0)
            {
                return;
            }
            if (_response.m_PlayInOrder)
            {
                DialogManager.Get.PlayDialog(dialogsLeft[0]);
                dialogsLeft.RemoveAt(0);
            }
            else if (_response.m_PseudoRandom)
            {
                Dialog dialog = dialogsLeft.Random();
                DialogManager.Get.PlayDialog(dialog);
                dialogsLeft.Remove(dialog);
            }
            else
            {
                DialogManager.Get.PlayDialog(dialogsLeft.Random());
            }
        }

        protected IEnumerator PlayAll(Response _response)
        {
            while (m_dialogsLeft[_response].Count > 0)
            {
                yield return new WaitUntil(() =>
                !DialogManager.Get.IsPlayingDialog);
                DialogManager.Get.PlayDialog(m_dialogsLeft[_response][0]);
                m_dialogsLeft[_response].RemoveAt(0);
            }
            m_playAllCoroutine = null;
        }
    }
}
