using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Katana : MonoBehaviour
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
                        result = judgingKatana();
                        Debug.Log(result);
                    }
                }
            }

            
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //刀を判定
        string judgingKatana(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool ha1 = -169.0 < start.x && start.x < -25.0;
                bool ha2 = -99.0 < start.y && start.y < 90.0;
                bool ha3 = -169.0 < end.x && end.x < 91.0;
                bool ha4 = -99.0 < end.y && end.y < 90.0;
                bool ha5 = sumDistance < 280.0;

                bool riki11 = -40.0 < start.x && start.x < 91.0;
                bool riki12 = 61.0 < start.y && start.y < 261.0;
                bool riki13 = -30.0 < end.x && end.x < 10.0;
                bool riki14 = 0.0 < end.y && end.y < 200.0;
                bool riki15 = sumDistance < 150.0;

                bool riki21 = -40.0 < start.x && start.x < 91.0;
                bool riki22 = 61.0 < start.y && start.y < 261.0;
                bool riki23 = -199.0 < end.x && end.x < 40.0;
                bool riki24 = -139.0 < end.y && end.y < 80.0;
                bool riki25 = sumDistance < 400.0;

            sumDistance = 0.0;

                if (ha1 & ha2 & ha3 & ha4 & ha5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "刃";
                } else if (riki11 & riki12 & riki13 & riki14 & riki15)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "力";
                }
                else if (riki21 & riki22 & riki23 & riki24 & riki25)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "力";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}