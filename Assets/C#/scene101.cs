using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene101 : MonoBehaviour
{
    private bool isReturnPressed;
    int isScene = 0;

    void Start()
    {
        DataManager.Instance.isReset = 1;
        DataManager.Instance.isBGM = 2;
        BGMManager.Instance.PlayBGM2();
    }

    void Update()
    {
        isScene = DataManager.Instance.isScene;
        if (isScene == 1)
        {
            DataManager.Instance.isReset = 1;
            isReturnPressed = true;
            DataManager.Instance.isScene = 0;
            StartCoroutine(WaitAndLoadScene(1.5f, "tutorial2"));
            if(DataManager.Instance.isCorrect >= 1)
            {
                StartCoroutine(WaitAndPlaySE(0.5f));
            }
        }
    }
    private IEnumerator WaitAndLoadScene(float seconds, string sceneName)
    {
        yield return new WaitForSeconds(seconds);
        if (isReturnPressed)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator WaitAndPlaySE(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SEManager.Instance.PlaySE1();
    }
}
