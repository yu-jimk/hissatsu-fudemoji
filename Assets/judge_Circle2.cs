using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class judge_Circle2 : MonoBehaviour
    {
        Vector3 start, end, beforeflame, nowflame; //宣言
        public Vector3 judgeObjTransform;
        private string result;
        double sumDistance = 0.0;
        bool isDownFirst = false; //下がって最初のフラグ
        bool isUpFirst = false; //上がって最初のフラグ
        public int isScene = 0;


        // Start is called before the first frame update
        void Start()
        {
            DataManager.Instance.isScene = 0;
        }

        // Update is called once per frame
        void Update()
        {

            if (SceneManager.GetActiveScene().name == "maru")
            {
                updateTransformData();
                //Debug.Log(judgeObjTransform);

                if (judgeObjTransform.z <= 0) //ドラッグしている間
                {
                    //下がって最初の時
                    if (isDownFirst == false)
                    {
                        isDownFirst = true;
                        isUpFirst = true;

                        start = judgeObjTransform; //開始地点の座標を取得
                        beforeflame = start;
                        Debug.Log("開始　　　　　円" + start);
                    }


                    nowflame = judgeObjTransform;
                    //Debug.Log("1個前" + beforeflame);
                    //Debug.Log("今" + nowflame);
                    //Debug.Log("長さ" + Vector3.Distance(beforeflame, nowflame));
                    sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
                    beforeflame = nowflame;
                }
                else
                {
                    if (isUpFirst)
                    {
                        isUpFirst = false;
                        isDownFirst = false;
                        result = judgingCircle();
                        Debug.Log(result);
                    }
                }
            }

        }

        //オブジェクトの位置を更新
        void updateTransformData()
        {
            judgeObjTransform = this.gameObject.transform.position;
        }

        //⚪︎を判定
        string judgingCircle()
        {
            end = judgeObjTransform; //終了地点の座標を取得
            Debug.Log("終了　　　　　円" + end);
            nowflame = end;
            sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);

            Debug.Log("長さ" + sumDistance);

            bool circle1 = (end.x - start.x) * (end.x - start.x) + (end.y - start.y) * (end.y - start.y) <= 20000;
            bool circle2 = 120 <= sumDistance;

            sumDistance = 0.0;

            if (circle1 & circle2) //条件と比較
            {
                Debug.Log("開始！");
                DataManager.Instance.isScene = 1;
                return "開始！";
            }
            else
            {
                Debug.Log("もう一度書けや");
                return "開始！";
            }

        }
    }
}