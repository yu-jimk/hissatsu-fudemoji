using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Nichi : MonoBehaviour
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
                        result = judgingNichi();
                        Debug.Log(result);
                    }
                }
            }
            

        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //日を判定
        string judgingNichi(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool me11 = -80.0 < start.x && start.x < -25.0;
                bool me12 = 30.0 < start.y && start.y < 137.0;
                bool me13 = 0.0 < end.x && end.x < 80.0;
                bool me14 = 30.0 < end.y && end.y < 137.0;
                bool me15 = sumDistance < 260.0;

                bool me21 = -80.0 < start.x && start.x < -25.0;
                bool me22 = -101.0 < start.y && start.y < 15.0;
                bool me23 = 0.0 < end.x && end.x < 80.0;
                bool me24 = -101.0 < end.y && end.y < 15.0;
                bool me25 = sumDistance < 260.0;


                bool ta1 = -83.0 < start.x && start.x < 83.0;
                bool ta2 = 31.0 < start.y && start.y < 110.0;
                bool ta3 = -83.0 < end.x && end.x < 83.0;
                bool ta4 = -110.0 < end.y && end.y < 11.0;
                bool ta5 = sumDistance < 400.0;

                bool kyu1 = -250.0 < start.x && start.x < -100.0;
                bool kyu2 = 21.0 < start.y && start.y < 261.0;
                bool kyu3 = -250.0 < end.x && end.x < -100.0;
                bool kyu4 = -209.0 < end.y && end.y < 21.0;
                bool kyu5 = sumDistance < 600.0;

                bool tan1 = -269.0 < start.x && start.x < -19.0;
                bool tan2 = -281.0 < start.y && start.y < -110.0;
                bool tan3 = 11.0 < end.x && end.x < 251.0;
                bool tan4 = -281.0 < end.y && end.y < -110.0;
                bool tan5 = sumDistance < 600.0;

                bool haku1 = -80.0 < start.x && start.x < 51.0;
                bool haku2 = 90.0 < start.y && start.y < 325.0;
                bool haku3 = -120.0 < end.x && end.x < 51.0;
                bool haku4 = 40.0 < end.y && end.y < 301.0;
                bool haku5 = sumDistance < 440.0;

                bool shin1 = -83.0 < start.x && start.x < 83.0;
                bool shin2 = 110.0 < start.y && start.y < 270.0;
                bool shin3 = -83.0 < end.x && end.x < 83.0;
                bool shin4 = -270.0 < end.y && end.y < -110.0;
                bool shin5 = sumDistance < 920.0;

                bool kou1 = -83.0 < start.x && start.x < 83.0;
                bool kou2 = 31.0 < start.y && start.y < 110.0;
                bool kou3 = -83.0 < end.x && end.x < 83.0;
                bool kou4 = -270.0 < end.y && end.y < -110.0;
                bool kou5 = sumDistance < 920.0;

                bool yu1 = -83.0 < start.x && start.x < 83.0;
                bool yu2 = 110.0 < start.y && start.y < 270.0;
                bool yu3 = -83.0 < end.x && end.x < 83.0;
                bool yu4 = -110.0 < end.y && end.y < 11.0;
                bool yu5 = sumDistance < 620.0;

                sumDistance = 0.0;

                if (me11 & me12 & me13 & me14 & me15) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                return "目";
                } else if (me21 & me22 & me23 & me24 & me25) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "目";
                } else if (ta1 & ta2 & ta3 & ta4 & ta5)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "田";
                } else if (kyu1 & kyu2 & kyu3 & kyu4 & kyu5)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "旧";
                } else if (tan1 & tan2 & tan3 & tan4 & tan5)
                {
                    DataManager.Instance.isCorrect = 4;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "旦";
                } else if (haku1 & haku2 & haku3 & haku4 & haku5)
                {
                    DataManager.Instance.isCorrect = 5;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "白";
                } else if (shin1 & shin2 & shin3 & shin4 & shin5)
                {
                    DataManager.Instance.isCorrect = 6;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "申";
                } else if (kou1 & kou2 & kou3 & kou4 & kou5)
                {
                    DataManager.Instance.isCorrect = 7;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "甲";
                } else if (yu1 & yu2 & yu3 & yu4 & yu5)
                {
                    DataManager.Instance.isCorrect = 8;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "由";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}