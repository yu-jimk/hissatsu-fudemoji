using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    int isCorrect = 0;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isCorrect = DataManager.Instance.isCorrect;

        // 左
        if (isCorrect == 1)
        {
            //DataManager.Instance.isCorrect = 0;

            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
            Debug.Log("Sound");
        }
    }
}
