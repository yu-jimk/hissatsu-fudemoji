using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    public AudioClip bgm1;
    public AudioClip bgm2;
    public AudioClip bgm3;
    public AudioClip bgm4;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM1()
    {
        audioSource.clip = bgm1;
        audioSource.Play();
    }

    public void PlayBGM2()
    {
        audioSource.clip = bgm2;
        audioSource.Play();
    }

    public void PlayBGM3()
    {
        audioSource.clip = bgm3;
        audioSource.Play();
    }

    public void PlayBGM4()
    {
        audioSource.clip = bgm4;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}
