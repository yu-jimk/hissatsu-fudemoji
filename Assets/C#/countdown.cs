using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public Text countdownText;
    public GameObject objectToHide;
    private float countdownTime = 3f; // カウントダウンの初期時間

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString("F0"); // テキストに残り時間を表示
            yield return new WaitForSeconds(1f); // 1秒待機
            countdownTime--;
        }

        countdownText.text = "GO!"; // カウントダウンが終了したら"GO!"を表示
        yield return new WaitForSeconds(1f); // "GO!"を表示してから1秒待機

        objectToHide.SetActive(false);
        countdownText.gameObject.SetActive(false);
    }
}