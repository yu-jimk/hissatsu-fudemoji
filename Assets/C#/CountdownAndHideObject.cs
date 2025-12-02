using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownAndHideObject : MonoBehaviour
{
    public Text countdownText;
    public GameObject objectToHide;
    private float countdownTime = 3f; // カウントダウンの初期時間

    // 数字を漢字に変換するための辞書
    private Dictionary<int, string> numberToKanji = new Dictionary<int, string>
    {
        {1, "一"},
        {2, "二"},
        {3, "三"},
        {4, "四"},
        {5, "五"},
        {6, "六"},
        {7, "七"},
        {8, "八"},
        {9, "九"},
        {10, "十"}
    };

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            int countdownNumber = Mathf.RoundToInt(countdownTime); // カウントダウン時間を整数に変換
            string kanjiText = numberToKanji.ContainsKey(countdownNumber) ? numberToKanji[countdownNumber] : countdownNumber.ToString(); // 数字を漢字に変換

            countdownText.text = kanjiText; // テキストに漢字を表示
            SEManager.Instance.PlaySE6();
            yield return new WaitForSeconds(1f); // 1秒待機
            countdownTime--;
        }

        countdownText.text = "GO!"; // カウントダウンが終了したら"GO!"を表示
        yield return new WaitForSeconds(1f); // "GO!"を表示してから1秒待機

        objectToHide.SetActive(false);
        countdownText.gameObject.SetActive(false);
    }
}


