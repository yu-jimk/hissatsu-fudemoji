using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager2 : MonoBehaviour
{
    public AudioClip sound1;
    private AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlaySoundAfterDelay(3f));
    }

    IEnumerator PlaySoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        audioSource.PlayOneShot(sound1);
        Debug.Log("Sound");
    }
}
