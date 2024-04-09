using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEngine.UI;
using TMPro;

namespace STORYGAME
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]

    public class GameSystemEditor : Editor
    {
        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();

            GameSystem gameSystem = (GameSystem)target;

            if (GUILayout.Button("Reset Story Models"))
            {
                gameSystem.ResetStoryModels();
            }

            if (GUILayout.Button("Assing Text Component by Name"))
            {
                GameObject textObject = GameObject.Find("StoryTextUI");
                if (textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if (textComponent != null)
                    {
                        gameSystem.textComponent = textComponent;
                        Debug.Log("Text Component assigned Successfully");
                    }
                }
            }
        }
    }

#endif
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;
        public Text textComponent = null;

        public float delay = 0.1f;
        public string fullText;
        public string currentText = "";

        public enum GAMESTATE
        {
            STORYSHOW,
            WAITSELECT,
            STROTYEND,
            ENDMODE
        }

        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;
        public StoryTableObject currentModels;
        public int currentStoryIndex;
        public bool showStory = false;

        private void Awake()
        {
            instance = this;
        }

        public void Start()
        {
            StartCoroutine(ShowText());
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);
            if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);
            if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                delay = 0.0f;
            }
        }

        public void StoryShow(int number)
        {
            if (!showStory)
            {
                currentModels = FindStoryModel(number);
                delay = 0.1f;
                StartCoroutine(ShowText());
            }
        }
        StoryTableObject FindStoryModel(int number)
        {
            StoryTableObject tempStoryModels = null;
            for (int i = 0; i < storyModels.Length; i++)
            {
                if (storyModels[i].storyNumber == number)
                {
                    tempStoryModels = storyModels[i];
                    break;
                }
            }
            return tempStoryModels;
        }
        IEnumerator ShowText()
        {
            showStory = true;
            for (int i = 0; i <= currentModels.storyText.Length; i++)
            {
                currentText = currentModels.storyText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delay);
            showStory = false;
        }

#if UNITY_EDITOR

        [ContextMenu("Reset Story Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");
        }

#endif
    }
}
