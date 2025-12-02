using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Ki : MonoBehaviour
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
                        result = judgingKi();
                        Debug.Log(result);
                    }
                }
            }
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //代を判定
        string judgingKi(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool mi1 = -220.0 < start.x && start.x < -39.0;
                bool mi2 = 65.0 < start.y && start.y < 146.0;
                bool mi3 = 35.0 < end.x; //&& end.x < 100.0;
                bool mi4 = 65.0 < end.y && end.y < 170.0;
                bool mi5 = sumDistance <= 200.0;

                bool sue1 = -220.0 < start.x && start.x < -39.0;
                bool sue2 = 65.0 < start.y && start.y < 146.0;
                bool sue3 = 35.0 < end.x; //&& end.x < 161.0;
                bool sue4 = 65.0 < end.y && end.y < 170.0;
                bool sue5 = 200.0 < sumDistance && sumDistance < 450.0;

                bool hon1 = -140.0 < start.x && start.x < -25.0;
                bool hon2 = -155.0 < start.y && start.y < -10.0;
                bool hon3 = 5.0 < end.x && end.x < 140.0;
                bool hon4 = -150.0 < end.y && end.y < -10.0;
                bool hon5 = sumDistance < 300.0;

                sumDistance = 0.0;

                if (mi1 & mi2 & mi3 & mi4 & mi5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "未";
                } else if (sue1 & sue2 & sue3 & sue4 & sue5)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "末";
                } else if (hon1 & hon2 & hon3 & hon4 & hon5)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "本";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}