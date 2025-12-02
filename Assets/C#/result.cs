using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    public GameObject score_object = null; // スコアテキストのオブジェクト
    public GameObject maxCombo_object = null; // 最大コンボ数テキストのオブジェクト
    public GameObject count_object = null;
    int score_first;
    int max;
    int isCount;

    // Start is called before the first frame update
    void Start()
    {
        max = DataManager.Instance.max;
        score_first = DataManager.Instance.score_first;
        isCount = DataManager.Instance.isCount;
    }

    // Update is called once per frame
    void Update()
    {
        // スコアのテキストオブジェクトを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示をスコアに更新
        score_text.text = "" + score_first;

        // 最大コンボ数のテキストオブジェクトを取得
        Text maxCombo_text = maxCombo_object.GetComponent<Text>();
        // テキストの表示を最大コンボ数に更新
        maxCombo_text.text = "" + max; // maxcomboは適切な方法で設定する必要があります

        Text count_text = count_object.GetComponent<Text>();
        // テキストの表示をスコアに更新
        count_text.text = "" + isCount;
    }
}
