using STORYGAME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static STORYGAME.StoryTableObject;


[CreateAssetMenu(fileName = "NewStory", menuName = "ScriptableObjects/StoryTableObject")]
public class StoryModel : ScriptableObject
{

    public int storyNumber;
    public Texture2D MainImage;

    public enum STORYTYPE
    {
        MAIN,
        SUB,
        SERIAL
    }

    public STORYTYPE storytype;
    public bool storyDone;

    [TextArea(10, 10)]
    public string storyText;

    public Option[] options;

    [System.Serializable]
    public class Option
    {
        public string optionText;
        public string buttonText;
        public EventCheck eventCheck;
    }

    [System.Serializable]
    public class EventCheck
    {
        public int checkValue;

        public enum EventType :int
        {
            NONE,
            GoToBattle,
            CheckSTR,
            CheckDEX,
            CheckCON,
            CheckCINT,
            CheckWIS,
            CheckCHA
        }

        public EventType eventType;

        public Result[] successResult;
        public Result[] failResult;

     }


        [System.Serializable]
    public class Result
    {
        public enum ResultType : int
        {
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoToNextStory,
            GoToRandomStory,
            GoToEnding
        }

        public ResultType resultType;
        public int value;
        public Stats stats;
    }
}