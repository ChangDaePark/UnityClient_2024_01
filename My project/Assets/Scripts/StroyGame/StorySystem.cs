using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StorySystem : MonoBehaviour
{
    public static StorySystem instance;
    public StoryModel currentStoryModel;

    public enum TEXTSYSTEM
    {
        DOING,
        SELECT,
        DONE,
        NONE
    }

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public Text textComponent;
    public Text storyIndex;
    public Image imageComponent;

    public Button[] buttonWay = new Button[3];
    public Text[] buttonWayText = new Text[3];

    public TEXTSYSTEM currentTextShow = TEXTSYSTEM.NONE;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonWay.Length; i++)
        {
            int wayIndex = i;
            buttonWay[i].onClick.AddListener(() => OnWayClick(wayIndex));
        }

        GoShowText();
    }

    public void StoryModelinit()
    {
        fullText = currentStoryModel.storyText;
        storyIndex.text = currentStoryModel.storyNumber.ToString();

        for (int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWayText[i].text = currentStoryModel.options[i].buttonText;
        }
    }

    public void OnWayClick(int index)
    {
        if (currentTextShow == TEXTSYSTEM.DOING)
            return;

        bool CheckEventTypeNone = false;
        StoryModel playStoryModel = currentStoryModel;

        if (playStoryModel.options[index].eventCheck.eventType == StoryModel.EventCheck.EventType.NONE)
        {
            for (int i = 0; i < playStoryModel.options[index].eventCheck.successResult.Length; i++)
            {
                GameSystem.instance.ApplyChoice(currentStoryModel.options[index].eventCheck.successResult[i]);
                CheckEventTypeNone = true;  
            }
        }
    }

    public void GoShowText()
    {
        StoryModelinit();
        ResetShow();
        StartCoroutine(ShowText());
    }

    public void ResetShow()
    {
        textComponent.text = "";

        for (int i = 0; i < buttonWay.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(false);
        }
    }
    
    IEnumerator ShowText()
    {
        currentTextShow = TEXTSYSTEM.DOING;

        if (currentStoryModel.MainImage != null)
        {
            Rect rect = new Rect(0, 0, currentStoryModel.MainImage.width, currentStoryModel.MainImage.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Sprite sprite = Sprite.Create(currentStoryModel.MainImage, rect, pivot);

            imageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("텍스쳐 로딩이 되지 않습니다. : " + currentStoryModel.MainImage.name);
        }

        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        for (int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(delay);

        currentTextShow = TEXTSYSTEM.NONE;

    }

}
