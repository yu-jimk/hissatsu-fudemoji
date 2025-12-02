using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance;

    public AudioClip SE1;   //正解の音
    public AudioClip SE2;   //不正解の音
    public AudioClip SE3;   //スコア加算の音
    public AudioClip SE4;   //板が割れる音
    public AudioClip SE5;   //終了の音
    public AudioClip SE6;   //カウントダウン
    public AudioClip SE7;   //開始の音

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

    public void PlaySE1()
    {
        audioSource.clip = SE1;
        audioSource.Play();
    }

    public void PlaySE2()
    {
        audioSource.clip = SE2;
        audioSource.Play();
    }

    public void PlaySE3()
    {
        audioSource.clip = SE3;
        audioSource.Play();
    }

    public void PlaySE4()
    {
        audioSource.clip = SE4;
        audioSource.Play();
    }

    public void PlaySE5()
    {
        audioSource.clip = SE5;
        audioSource.Play();
    }

    public void PlaySE6()
    {
        audioSource.clip = SE6;
        audioSource.Play();
    }

    public void PlaySE7()
    {
        audioSource.clip = SE7;
        audioSource.Play();
    }
}
