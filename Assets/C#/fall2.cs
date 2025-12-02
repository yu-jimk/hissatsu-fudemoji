using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall2 : MonoBehaviour
{

    public GameObject someGameObject;
    int isFalse = 0;

    // Start is called before the first frame update
    void Start()
    {
        someGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isFalse = DataManager.Instance.isFalse;

        if (someGameObject != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isFalse == 2)
            {
                DataManager.Instance.isFalse = 0;
                someGameObject.SetActive(true);
            }
        }


    }
}
