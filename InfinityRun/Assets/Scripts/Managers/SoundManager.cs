using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static AudioSource _audioSource;

    private static AudioSource _audioSourceBackground;
    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
            }

            return _instance;
        }
    }

    public AudioClip JumpSound;
    public AudioClip FallSound;
    public AudioClip BackgroundMusic;
    public AudioClip BumpSound;



    void Start()
    {
        _audioSourceBackground = GetComponents<AudioSource>()[0];
        _audioSource = GetComponents<AudioSource>()[1];
        DontDestroyOnLoad(gameObject);
        _instance = this;
        PlayBackgroundMusic();

    }

    public static void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayJumpSound()
    {
        PlaySound(JumpSound);
    }

    public void PlayFallSound()
    {
        PlaySound(FallSound);
        Console.WriteLine("Fall sound played");
        Debug.Log("Fall sound played");
    }

    private void PlayBackgroundMusic()
    {
        if (BackgroundMusic != null)
        {
            _audioSourceBackground.clip = BackgroundMusic;
            _audioSourceBackground.Play();

        }
        else
        {
            Debug.LogWarning("Background Music is not assigned to SoundManager!");
        }
    }

    public void PlayBumpSound()
    {
        PlaySound(BumpSound);
    }


}

