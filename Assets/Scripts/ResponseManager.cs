using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseManager : MonoBehaviour
{
    public static ResponseManager Get { get; private set; }

    private Dictionary<Response, List<Dialog>> m_dialogsLeft
        = new Dictionary<Response, List<Dialog>>();
    private Coroutine m_playAllCoroutine;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }

    public void ShowResponse(Response _response)
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

    private void PlayOneDialog(Response _response)
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

    private IEnumerator PlayAll(Response _response)
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
