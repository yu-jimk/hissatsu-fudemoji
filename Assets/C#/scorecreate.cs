using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorecreate : MonoBehaviour
{
    public GameObject someGameObject;
    private float delay = 2.9f;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクトを非アクティブに設定
        if (someGameObject != null)
        {
            someGameObject.SetActive(false);
        }

        // 3秒後に ActivateGameObject メソッドを呼び出す
        StartCoroutine(ActivateGameObjectAfterDelay(delay));
    }

    IEnumerator ActivateGameObjectAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // 遅延後にゲームオブジェクトをアクティブに設定
        if (someGameObject != null)
        {
            someGameObject.SetActive(true);
        }

        activated = true; // ゲームオブジェクトがアクティブになったことを記録
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            // ゲームオブジェクトがアクティブになった後の処理をここに記述
        }
    }
}

