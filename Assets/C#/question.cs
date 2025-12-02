using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class question : MonoBehaviour
{
    public int isCorrect = 0;
    public int isFalse = 0;
    public int isdivide = 0;
    public int isScene = 0;
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.isCorrect = 0;
        DataManager.Instance.isFalse = 0;
        DataManager.Instance.isdivide = 0;
        DataManager.Instance.isScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            DataManager.Instance.isCorrect = 1;
            DataManager.Instance.isdivide = 1;
            DataManager.Instance.isScene = 1;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DataManager.Instance.isFalse = 1;
            DataManager.Instance.isScene = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            DataManager.Instance.isCorrect = 101;
            DataManager.Instance.isdivide = 2;
            DataManager.Instance.isScene = 1;
        }

        
    }
}
