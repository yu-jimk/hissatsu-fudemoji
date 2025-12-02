using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundcreate : MonoBehaviour
{

    public GameObject someGameObject;
    int isScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        someGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isScene = DataManager.Instance.isScene;

        if (someGameObject != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isScene == 1)
            {
                //DataManager.Instance.isFalse = 0;
                someGameObject.SetActive(true);
            }
        }


    }
}
