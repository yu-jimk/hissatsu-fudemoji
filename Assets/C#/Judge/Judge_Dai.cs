using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Dai : MonoBehaviour
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
        public int Count = 0;

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
                        result = judgingDai();
                        Debug.Log(result);
                    }
                }

            }    
            
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //大を判定
        string judgingDai(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool inu1 = 20.0 < start.x && start.x < 205.0;
                bool inu2 = 27.0 < start.y && start.y < 255.0;
                bool inu3 = -20.0 < end.x && end.x < 205.0;
                bool inu4 = 27.0 < end.y && end.y < 255.0;
                bool inu5 = sumDistance < 220.0;

                bool ten1 = -217.0 < start.x && start.x < -11.0;
                bool ten2 = 3.0 < start.y && start.y < 261.0;
                bool ten3 = 11.0 < end.x; //&& end.x < 239.0;
                bool ten4 = 3.0 < end.y && end.y < 231.0;
                bool ten5 = 120 < sumDistance && sumDistance < 1700.0;

                bool ki1 = -69.0 < start.x && start.x < 61.0;
                bool ki2 = -21.0 < start.y && start.y < 300.0;
                bool ki3 = -89.0 < end.x && end.x < 71.0;
                bool ki4 = -259.0 < end.y && end.y < -39.0;
                bool ki5 = sumDistance < 1200.0;

                bool ta1 = -109.0 < start.x && start.x < 131.0;
                bool ta2 = -229.0 < start.y && start.y < 61.0;
                bool ta3 = -109.0 < end.x && end.x < 131.0;
                bool ta4 = -319.0 < end.y && end.y < 39.0;
                bool ta5 = sumDistance < 220.0;

                bool hu1 = -128.0 < start.x && start.x < 31.0;
                bool hu2 = 3.0 < start.y && start.y < 130.0;
                bool hu3 = 11.0 < end.x; //&& end.x < 130.0;
                bool hu4 = 3.0 < end.y && end.y < 119.0;
                bool hu5 = sumDistance < 200.0;

                sumDistance = 0.0;

                if (inu1 & inu2 & inu3 & inu4 & inu5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "犬";
                } else if (ten1 & ten2 & ten3 & ten4 & ten5)
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                return "天";
                } else if (ki1 & ki2 & ki3 & ki4 & ki5)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "木";
                } else if (ta1 & ta2 & ta3 & ta4 & ta5)
                {
                    DataManager.Instance.isCorrect = 4;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;   
                    return "太";
                } else if (hu1 & hu2 & hu3 & hu4 & hu5)
                {
                    DataManager.Instance.isCorrect = 5;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "夫";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}