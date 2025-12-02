using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ture : MonoBehaviour
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
            if (isCorrect == 1)
            {
                someGameObject1.SetActive(true);
                //SEManager.Instance.PlaySE1();
            }
        }

        if (someGameObject2 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 2)
            {
                someGameObject2.SetActive(true);
                //SEManager.Instance.PlaySE1();
            }
        }

        if (someGameObject3 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 3)
            {
                someGameObject3.SetActive(true);
                //SEManager.Instance.PlaySE1();
            }
        }

        if (someGameObject4 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 4)
            {
                someGameObject4.SetActive(true);
               // SEManager.Instance.PlaySE1();
            }
        }

        if (someGameObject5 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 5)
            {
                someGameObject5.SetActive(true);
                //SEManager.Instance.PlaySE1();
            }
        }

        if (someGameObject6 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 6)
            {
                someGameObject6.SetActive(true);
                //SEManager.Instance.PlaySE1();
            }
        }

        if (someGameObject7 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 7)
            {
                someGameObject7.SetActive(true);
                //SEManager.Instance.PlaySE1();
            }
        }

        if (someGameObject8 != null)
        {
            // ゲームオブジェクトが存在する場合の処理
            if (isCorrect == 8)
            {
                someGameObject8.SetActive(true);
                //SEManager.Instance.PlaySE1();
            }
        }

    }
}
