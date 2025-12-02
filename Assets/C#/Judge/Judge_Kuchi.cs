using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Kuchi : MonoBehaviour
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
                        result = judgingKuchi();
                        //Debug.Log(result);
                    }
                }
            }

                
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //口を判定
        string judgingKuchi(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);

                Debug.Log("長さ" + sumDistance);
                
                bool nichi1 = -130.0 < start.x && start.x < -45.0;
                bool nichi2 = -35.0 < start.y && start.y < 52.0;
                bool nichi3 = 41.0 < end.x && end.x < 130.0;
                bool nichi4 = -35.0 < end.y && end.y < 52.0;
                bool nichi5 = sumDistance < 250.0;

                bool naka1 = -50.0 < start.x && start.x < 45.0;
                bool naka2 = 119.0 < start.y && start.y < 231.0;
                bool naka3 = -50.0 < end.x && end.x < 45.0;
                bool naka4 = -240.0 < end.y && end.y < -80.0;
                bool naka5 = sumDistance < 500.0;

                sumDistance = 0.0;

                if (nichi1 & nichi2 & nichi3 & nichi4 & nichi5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    Debug.Log("日");
                    //SceneManager.LoadScene("NewGameScene2"); //画面遷移
                    return "日";
                } else if (naka1 & naka2 & naka3 & naka4 & naka5)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    Debug.Log("中");
                    //SceneManager.LoadScene("NewGameScene2"); //画面遷移
                    return "中";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    Debug.Log("不正解");
                    //SceneManager.LoadScene("NewGameScene");
                    return "不正解";
                }

        }
    }
}