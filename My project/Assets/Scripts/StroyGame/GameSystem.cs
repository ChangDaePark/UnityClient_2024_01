using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

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
        }
    }

#endif
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;

        private void Awake()
        {
            instance = this;
        }

        public StoryTableObject[] storyModels;

        [ContextMenu("Reset Story Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");
        }

#if Unity_Editor

        [ContextMenu("Reset Story Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");
        }

#endif
    }
}

