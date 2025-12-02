using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class limit : MonoBehaviour
{
    public float timeLimit = 60f; // 制限時間（60秒）
    private float currentTime;    // 現在の時間
    private bool isReturnPressed;
    public int create = 0;
    public GameObject objectToDisplay;

    public Text timerText; // タイマーのテキストを表示するUIテキスト

    private void Start()
    {
        // 2秒の遅延後にカウントダウンを開始するコルーチンを呼び出す
        StartCoroutine(StartCountdownAfterDelay(0.9f));

    }

    private IEnumerator StartCountdownAfterDelay(float delaySeconds)
    {
        // 指定した遅延時間だけ待機
        yield return new WaitForSeconds(delaySeconds);

        // カウントダウンを開始
        currentTime = timeLimit;

        // カウントダウンが終了するまでのループ
        while (currentTime > 0f)
        {
            currentTime -= Time.deltaTime; // 毎フレームの時間を減算

            // タイマーが0未満にならないように制限
            if (currentTime < 0f)
            {
                currentTime = 0f;
                // タイムアップ時の処理をここに追加
                Debug.Log("Time's up!");
            }

            // UIテキストに残り時間を表示
            timerText.text = "" + Mathf.CeilToInt(currentTime).ToString();

            yield return null;
        }

        // タイムアップ時の処理を行う場合はここでゲームを終了するなどの処理を追加
        if (currentTime <= 0f)
        {
            DataManager.Instance.isBGM = 1;
            DisplayObject();
            isReturnPressed = true;
            StartCoroutine(WaitAndLoadScene(1.5f, "ending"));
            SEManager.Instance.PlaySE5();
        }

        IEnumerator WaitAndLoadScene(float seconds, string sceneName)
        {
            yield return new WaitForSeconds(seconds);
            if (isReturnPressed)
            {
                SceneManager.LoadScene(sceneName);
                DataManager.Instance.create = 1;
            }
        }
        void DisplayObject()
        {
            objectToDisplay.SetActive(true);
        }

    }
}
