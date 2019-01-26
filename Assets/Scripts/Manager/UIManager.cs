using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Get { get; private set; }

    public Image m_FadeImage;
    public TextMeshProUGUI m_HoverText;

    public Image[] m_FirstRowItems;
    public Image[] m_SecondRowItems;

    public Color m_InteractionDefaultColor;
    public Color m_InteractionHighlightedColor;
    public Button[] m_InteractionButtons;

    public RectTransform m_QuestPanel;
    public TextMeshProUGUI m_QuestName;
    public TextMeshProUGUI m_QuestDescription;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }

    private void Start()
    {
        DisplayInventoryItems(new PickableObject[0]);
        ResetInteractionHighlighting();
    }

    public void FadeInOut(float _blackTime, float _fadeDuration)
    {
        StartCoroutine(AsyncFadeInOut(_blackTime, _fadeDuration));
    }

    private IEnumerator AsyncFadeInOut(float _blackTime, float _fadeDuration)
    {
        StartCoroutine(AsyncFadeToColor(Color.black, _fadeDuration));
        yield return new WaitForSeconds(_blackTime);
        StartCoroutine(AsyncFadeToColor(new Color(1, 1, 1, 0), _fadeDuration));
    }

    private IEnumerator AsyncFadeToColor(Color _color, float _time)
    {
        float time = _time;
        float lerpTime = 0;
        Color startColor = m_FadeImage.color;
        while (time > 0)
        {
            lerpTime += Time.deltaTime / _time;
            m_FadeImage.color = Color.Lerp(startColor, _color, lerpTime);
            time -= Time.deltaTime;
            yield return null;
        }
    }

    public void SetInteractionType(int _type)
    {
        GameManager.Get.m_CurrentInteractionType = (EInteractionType)_type;
        ResetInteractionHighlighting();
        m_InteractionButtons[_type - 1].GetComponentInChildren<Text>().color = m_InteractionHighlightedColor;
    }

    public void SelectItem(int _index)
    {
        if (GameManager.Get.m_CurrentInteractionType != EInteractionType.PICK_UP)
        {
            GameManager.Get.GetObjectFromIndex(_index).Interact();
            return;
        }
        ResetItemHighlighting();
        GameManager.Get.SelectInventoryItem(_index);
        if (_index < 3)
        {
            m_FirstRowItems[_index].color = Color.green;
            return;
        }
        m_SecondRowItems[_index - 3].color = Color.green;
    }

    public void DisplayInventoryItems(PickableObject[] _items)
    {
        for (int i = 0; i < 6; i++)
        {
            if (i < _items.Length)
            {
                if (i < 3)
                {
                    m_FirstRowItems[i].sprite = _items[i].m_InventorySprite;
                    m_FirstRowItems[i].enabled = true;
                    m_FirstRowItems[i].preserveAspect = true;
                }
                else
                {
                    m_SecondRowItems[i - 3].sprite = _items[i].m_InventorySprite;
                    m_SecondRowItems[i - 3].enabled = true;
                    m_SecondRowItems[i - 3].preserveAspect = true;
                }
            }
            else
            {
                if (i < 3)
                {
                    m_FirstRowItems[i].sprite = null;
                    m_FirstRowItems[i].enabled = false;
                    m_FirstRowItems[i].preserveAspect = true;
                }
                else
                {
                    m_SecondRowItems[i - 3].sprite = null;
                    m_SecondRowItems[i - 3].enabled = false;
                    m_SecondRowItems[i - 3].preserveAspect = true;
                }
            }
        }
    }

    public void InventoryArrowUp()
    {
        GameManager.Get.InventoryRow++;
    }

    public void InventoryArrowDown()
    {
        GameManager.Get.InventoryRow--;
    }

    public void DisplayHoverItem(ClickableObject _object)
    {
        if (_object == null)
        {
            m_HoverText.text = "";
            return;
        }
        m_HoverText.text = _object.m_ObjectName;
    }

    public void ToggleDisplayCurrentQuest(Quest _quest)
    {
        if (_quest == null)
        {
            m_QuestName.text = "You have no task";
            m_QuestDescription.text = "";
        }
        else
        {
            m_QuestName.text = _quest.QuestName;
            m_QuestDescription.text = _quest.Goal;
        }
        m_QuestPanel.gameObject.SetActive(!m_QuestPanel.gameObject.activeSelf);
    }

    private void ResetItemHighlighting()
    {
        foreach (Image image in m_FirstRowItems)
        {
            image.color = Color.white;
        }

        foreach (Image image in m_SecondRowItems)
        {
            image.color = Color.white;
        }
    }

    private void ResetInteractionHighlighting()
    {
        foreach (Button button in m_InteractionButtons)
        {
            button.GetComponentInChildren<Text>().color = m_InteractionDefaultColor;
        }
    }
}
