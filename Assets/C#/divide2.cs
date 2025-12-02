using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class divide2 : MonoBehaviour
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

        if (isdivide == 2)
        {
            DataManager.Instance.isScene = 2;
            DataManager.Instance.isdivide = 0;
            Destroy(this.gameObject);
        }
    }
    
}