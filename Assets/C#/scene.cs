using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{ 
    int isScene = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        isScene = DataManager.Instance.isScene;
        if (isScene == 1)
         {
            DataManager.Instance.isCorrect = 0;
            DataManager.Instance.isScene = 0;
            DataManager.Instance.isReset = 1;
            DataManager.Instance.isBGM = 1;
            SceneManager.LoadScene("tutorial");
        }
    }
}
