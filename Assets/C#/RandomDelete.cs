using UnityEngine;

public class RandomDelete : MonoBehaviour
{
    // ここにシーン1のスクリプトの内容を記述

    void Start()
    { 
        DataManager.Instance.isBGM = 1;
        DataManager.Instance.isSound = 1;
        DataManager.Instance.create = 1;

        // このスクリプトを削除
        Destroy(GameObject.FindObjectOfType<RandomScene>().gameObject);
    }
    
    // 他のメソッドや処理を続ける
}