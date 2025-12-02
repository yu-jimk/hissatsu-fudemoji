using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RandomScene : MonoBehaviour
{
    List<int> numbers = new List<int>();
    float timeSinceLastSceneChange = 0f;
    public float initialSceneChangeDelay = 3f; // 最初のシーン切り替えの遅延
    public float sceneChangeInterval = 5f; // シーン切り替えのインターバル

    bool isFirstSceneChange = true;

    int isScene = 0;

    void Start()
    {
        DataManager.Instance.isReset = 1;
        DataManager.Instance.isBGM = 3;

        DontDestroyOnLoad(this);

        for (int i = 7; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            numbers.Add(i);
        }

        numbers.Remove(SceneManager.GetActiveScene().buildIndex);

        // 最初のシーン切り替えを遅延させる
        timeSinceLastSceneChange = initialSceneChangeDelay;
    }

    void Update()
    {
        isScene = DataManager.Instance.isScene;

        if (isFirstSceneChange)
        {
            // 初回のシーン切り替えを待つ
            timeSinceLastSceneChange -= Time.deltaTime;

            if (timeSinceLastSceneChange <= 0f)
            {
                RandomSceneChange();
                isFirstSceneChange = false;
                SEManager.Instance.PlaySE7();
            }
        }
        else
        {
            // リターンキーが押されたらランダムにシーン切り替える
            if (isScene == 1)
            {
                DataManager.Instance.isReset = 1;
                DataManager.Instance.isScene = 0;
                Invoke("RandomSceneChangeWithDelay", 1.5f);
                if(DataManager.Instance.isCorrect >= 1)
                {
                    StartCoroutine(WaitAndPlaySE(0.5f));
                    DataManager.Instance.isCorrect = 0;
                }
            }
        }
    }

    void RandomSceneChangeWithDelay()
    {
        RandomSceneChange();
    }

    void RandomSceneChange()
    {
        if (numbers.Count > 0)
        {
            int randomIndex = Random.Range(0, numbers.Count);
            int sceneIndexToLoad = numbers[randomIndex];

            numbers.RemoveAt(randomIndex);
            SceneManager.LoadScene(sceneIndexToLoad);

            Debug.Log("Scene changed to build index: " + sceneIndexToLoad);
        }
        else
        {
            Debug.Log("No more scenes to load. Switching to Scene 1.");
            SceneManager.LoadScene(0); // シーン1のビルドインデックス
        }
    }

    private IEnumerator WaitAndPlaySE(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SEManager.Instance.PlaySE1();
    }
}
