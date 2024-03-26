using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME
{  public class Enums
    {
        public enum StoryType
        {
            MAIN,
            SUB,
            SERIAL
        }

        public enum EvenType
        {
            NONE,
            GoToBattle = 100,
            CheckSTR = 1000,
            CheckDex,
            CheckCON,
            CHECKWIS,
            CheckCHA
        }

        public enum ResultType
        {
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoToRandeomStory,
            GoToEnding
        }
    }

    [System.Serializable]

    public class Stats
    {

        public int hpPoint;
        public int spPoint;

        public int currentHpPoint;
        public int currentSpPoint;
        public int currentXpPoint;

        public int strength;
        public int dexterity;
        public int consitiution;
        public int Intelligence;
        public int wisdon;
        public int charisma;

    }
}




