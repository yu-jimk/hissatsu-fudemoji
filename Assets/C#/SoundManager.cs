using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;
    int isCorrect = 0;
    int isFalse = 0;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isCorrect = DataManager.Instance.isCorrect;

        // 左
        if (isCorrect >= 1)
        {
            //DataManager.Instance.isCorrect = 0;

            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
            Debug.Log("Sound");
        }

        if (DataManager.Instance.isScore == 1)
        {
            //DataManager.Instance.isCorrect = 0;

            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound2);
            Debug.Log("Sound");
        }

        if (DataManager.Instance.isFalse == 1)
        {
            //DataManager.Instance.isCorrect = 0;

            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound3);
            Debug.Log("Sound");
        }
    }
}
