using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.isReset = 1;
        BGMManager.Instance.PlayBGM1();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            DataManager.Instance.isReset = 1;
            SceneManager.LoadScene("scene");
        }
    }
}
