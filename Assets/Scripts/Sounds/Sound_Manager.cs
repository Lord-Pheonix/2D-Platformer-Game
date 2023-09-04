using System;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    private static Sound_Manager instance;
    public static Sound_Manager Instance { get { return instance; } }

    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioType[] type;

    public AudioSource SoundEffect { get { return soundEffect; } }

    private void Awake()
    {
        if (instance == null)    //checking if instance is null 
        {
            instance = this;   //pointing to the current gameobject where this script is attached
            DontDestroyOnLoad(gameObject);   //to not destroy this gameobject through the whole game
        }
        else
        {
            Destroy(gameObject);    //and if this script is not attacthed to the other gameobject then destroy those gameobject
        }
    }

    public void PlayMusic(AudioClips audio)
    {
        AudioClip clip = GetAudioClip(audio);
        if (clip != null)
        {
            music.clip = clip;
            music.Play();
        }
        else
        {
            Debug.LogError("Clip not found for audio type : " + audio);
        }
    }

    public void StopMusic(AudioClips audio)
    {
        AudioClip clip = GetAudioClip(audio);
        if (clip != null)
        {
            music.clip = clip;
            music.Stop();
        }
    }

    public void Play(AudioClips audio)
    {
        AudioClip clip = GetAudioClip(audio);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for audio type : " +audio);
        }
    }

    private AudioClip GetAudioClip(AudioClips audio)
    {
        AudioType Type = Array.Find(type, Audio => Audio.audioType == audio);
        if (Type != null)
            return Type.audioClip;
        return null;
    }
}

[Serializable]
public class AudioType
{
    public AudioClips audioType;
    public AudioClip audioClip;
}