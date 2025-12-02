using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene104 : MonoBehaviour
{
    private bool isReturnPressed;
    int isScene = 0;

    void Start()
    {
        DataManager.Instance.isReset = 1;
        BGMManager.Instance.StopBGM();
    }

    void Update()
    {
        isScene = DataManager.Instance.isScene;
        if (isScene == 1)
        {
            DataManager.Instance.isReset = 1;
            DataManager.Instance.isScene = 0;
            isReturnPressed = true;
            StartCoroutine(WaitAndLoadScene(0.0f, "countdown"));
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

   
}
