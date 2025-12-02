using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Kanau : MonoBehaviour
    {
        Vector3 start, end, beforeflame, nowflame; //宣言
        public Vector3 judgeObjTransform;
        private string result;
        double sumDistance = 0.0;
        bool isDownFirst = false; //下がって最初のフラグ
        bool isUpFirst = false; //上がって最初のフラグ

        public int isCorrect = 0;
        public int isFalse = 0;
        public int isdivide = 0;
        public int isScene = 0;

        public bool StartDelay = false;
        // Start is called before the first frame update
        void Start()
        {
            DataManager.Instance.isCorrect = 0;
            DataManager.Instance.isFalse = 0;
            DataManager.Instance.isdivide = 0;
            DataManager.Instance.isScene = 0;

            Invoke("TrueBool", 0.1f);
        }

        void TrueBool()
        {
            StartDelay = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (StartDelay)
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
                        Debug.Log("開始" + start);
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
                        result = judgingKanau();
                        Debug.Log(result);
                    }
                }
            }

           
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //叶を判定
        string judgingKanau(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool to1 = -129.0 < start.x && start.x < 40.0;
                bool to2 = -189.0 < start.y && start.y < -29.0;
                bool to3 = 51.0 < end.x && end.x < 241.0;
                bool to4 = -189.0 < end.y && end.y < -29.0;
                bool to5 = sumDistance < 620.0;

                bool kyou1 = -69.0 < start.x && start.x < 75.0;
                bool kyou2 = 57.0 < start.y && start.y < 201.0;
                bool kyou3 = -69.0 < end.x && end.x < 81.0;
                bool kyou4 = -31.0 < end.y && end.y < 101.0;
                bool kyou5 = sumDistance < 250.0;


                sumDistance = 0.0;

                if (to1 & to2 & to3 & to4 & to5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "吐";
                } else if (kyou1 & kyou2 & kyou3 & kyou4 & kyou5)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "叫";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}