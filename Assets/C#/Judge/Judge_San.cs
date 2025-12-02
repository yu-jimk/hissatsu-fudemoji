using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_San : MonoBehaviour
    {
        Vector3 start, end, beforeflame, nowflame; //宣言
        public Vector3 judgeObjTransform;
        private string result;
        double sumDistance = 0.0;
        int relayyo1 = 0, relayyo2 = 0;
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

                        //nowflame = judgeObjTransform;
                        //Debug.Log("1個前" + beforeflame);
                        //Debug.Log("今" + nowflame);
                        //Debug.Log("長さ" + Vector3.Distance(beforeflame, nowflame));
                        //sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
                        //beforeflame = nowflame;
                    }

                    //曲がりポイント
                    //nowflame = Input.mousePosition;
                    if (-139.0 < nowflame.x && nowflame.x < -69.0 && -20.0 < nowflame.y && nowflame.y < 47.0)
                    {
                        relayyo1 = 1;
                        Debug.Log("1");
                    }

                    if (51.0 < nowflame.x && nowflame.x < 131.0 && -20.0 < nowflame.y && nowflame.y < 47.0 && relayyo1 == 1)
                    {
                        relayyo2 = 1;
                        Debug.Log("2");
                    }

                    nowflame = judgeObjTransform;
                    sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
                    beforeflame = nowflame;
                }
                else
                {
                    if (isUpFirst)
                    {
                        isUpFirst = false;
                        isDownFirst = false;
                        result = judgingSan();
                        Debug.Log(result);
                    }
                }
            }
             
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //三を判定
        string judgingSan(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool ou1 = -47.0 < start.x && start.x < 47.0;
                bool ou2 = 50.0 < start.y && start.y < 120.0;
                bool ou3 = -47.0 < end.x && end.x < 47.0;
                bool ou4 = -120.0 < end.y && end.y < -50.0;
                bool ou5 = sumDistance < 400.0;

                bool yo1 = -130 < start.x && start.x< -50; 
                bool yo2 = 131 < start.y && start.y < 225; 
                bool yo3 = -79 < end.x && end.x < 61; 
                bool yo4 = -239 < end.y && end.y < -119;
                bool yo5 = sumDistance < 800;
                bool yo6 = relayyo1 == 1;
                bool yo7 = relayyo2 == 1;

                sumDistance = 0.0;

                if (ou1 & ou2 & ou3 & ou4 & ou5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "王";
                } else if (yo1 & yo2 & yo3 & yo4 & yo5 & yo6 & yo7)
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "与";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}