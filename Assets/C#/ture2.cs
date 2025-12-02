using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ture2 : MonoBehaviour
{

    public GameObject someGameObject1;
    public GameObject someGameObject2;
    public GameObject someGameObject3;
    public GameObject someGameObject4;
    public GameObject someGameObject5;
    public GameObject someGameObject6;
    public GameObject someGameObject7;
    public GameObject someGameObject8;
    int isCorrect = 0;
    int isFalse = 0;

    // Start is called before the first frame update
    void Start()
    {
        someGameObject1.SetActive(false);
        someGameObject2.SetActive(false);
        someGameObject3.SetActive(false);
        someGameObject4.SetActive(false);
        someGameObject5.SetActive(false);
        someGameObject6.SetActive(false);
        someGameObject7.SetActive(false);
        someGameObject8.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCorrect = DataManager.Instance.isCorrect;
        isFalse = DataManager.Instance.isFalse;

        if (someGameObject1 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 101)
            {
                someGameObject1.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

        if (someGameObject2 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 102)
            {
                someGameObject2.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

        if (someGameObject3 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 103)
            {
                someGameObject3.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

        if (someGameObject4 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 104)
            {
                someGameObject4.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

        if (someGameObject5 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 105)
            {
                someGameObject5.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

        if (someGameObject6 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 106)
            {
                someGameObject6.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

        if (someGameObject7 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 107)
            {
                someGameObject7.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

        if (someGameObject8 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 108)
            {
                someGameObject8.SetActive(true);
                //DataManager.Instance.isCorrect == 300;
            }
        }

    }
}
