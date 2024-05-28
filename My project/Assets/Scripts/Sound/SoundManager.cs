using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(0f, 3f)]
    public float pitch = 1f;
    public bool loop;
    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource soruce;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<Sound> sounds = new List<Sound>();
    public AudioMixer audioMixer;

    private void Awake()
    {
       if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
       else
        {
            Destroy(gameObject);
        }
        
       foreach (Sound sound in sounds)
        {
            sound.soruce = gameObject.AddComponent<AudioSource>();
            sound.soruce.clip = sound.clip;
            sound.soruce.volume = sound.volume;
            sound.soruce.pitch = sound.pitch;
            sound.soruce.loop = sound.loop;
            sound.soruce.outputAudioMixerGroup = sound.mixerGroup;
        }

    }

    public void PlaySound(string name)
    {
        Sound soundToPlay = sounds.Find(sound => sound.name == name);

        if (soundToPlay != null)
        {
            soundToPlay.soruce.Play();
        }
        else
        {
            Debug.LogWarning("사운드" + name + "찾을 수 없습니다");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
