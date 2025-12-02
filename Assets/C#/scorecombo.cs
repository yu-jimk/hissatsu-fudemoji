using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecombo : MonoBehaviour
{
    public GameObject score_object = null; // Textオブジェクト
    public int score_num = 0; // スコア変数
    public int score_first = 0;
    public int Count = 0;
    public int score_correct = 0;
    public int max = 0;
    public int isCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        score_first = 0;
        Count = 0;
        max = 0;
        DataManager.Instance.score_first = 0;
        DataManager.Instance.max = 0;
        DataManager.Instance.isCorrect = 0;
        DataManager.Instance.isCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "Score: " + score_first;
        if (DataManager.Instance.isCorrect >= 1)
        {
            score_correct = 1;
            DataManager.Instance.isScore = 1;
            //SEManager.Instance.PlaySE3();
        }
        else if (DataManager.Instance.isFalse == 1)
        {
            score_correct = 2;
            //DataManager.Instance.isFalse = 0;
        }

        if (score_correct == 1)
        {
            if (Count == 0)
            {
                score_num += 500; // リターンキーを押すと100点加算
                score_first += score_num;
                score_num = 0;
                Count += 1;
            }
            else
            {
                score_num += 500 + 100 * (Count + 1); // リターンキーを押すと100点加算
                score_first += score_num;
                score_num = 0;
                Count += 1;
            }
            score_correct = 0;
            isCount += 1;
            Debug.Log("score: " + score_first);
        }
        else if (score_correct == 2)
        {
            Count = 0;
        }

        if (max < Count)
        {
            max = Count;
            Debug.Log("max: " + max);
        }

        DataManager.Instance.score_first = score_first;
        DataManager.Instance.max = max;
        DataManager.Instance.isCount = isCount;
    }

}
