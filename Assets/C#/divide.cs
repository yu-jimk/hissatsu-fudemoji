using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class divide : MonoBehaviour
{
    int isCorrect = 0;
    int isFalse = 0;
    int isdivide = 0;

    void Start()
    {
        DataManager.Instance.isCorrect = 0;
        DataManager.Instance.isFalse = 0;
        DataManager.Instance.isdivide = 0;
    }

    void Update()
    {
        isCorrect = DataManager.Instance.isCorrect;
        isFalse = DataManager.Instance.isFalse;
        isdivide = DataManager.Instance.isdivide;

        if (isdivide == 1)
        {
            DataManager.Instance.isScene = 1;
            DataManager.Instance.isdivide = 0;
            Destroy(this.gameObject);
        }
    }
}