using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_T02 : MonoBehaviour
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
                        result = judgingUshinau();
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

        //判定
        string judgingUshinau()
        {
            end = judgeObjTransform; //終了地点の座標を取得
            Debug.Log("終了" + end);
            nowflame = end;
            sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);

            Debug.Log("長さ" + sumDistance);
            bool ue1 = 0.0 < start.x && start.x < 50.0;
            bool ue2 = -80.0 < start.y && start.y < 140.0;
            bool ue3 = 50.0 < end.x && end.x < 200.0;
            bool ue4 = -80.0 < end.y && end.y < 140.0;
            bool ue5 = sumDistance < 300.0;

            bool kou1 = -150.0 < start.x && start.x < 0.0;
            bool kou2 = 140.0 < start.y && start.y < 200.0;
            bool kou3 = 0.0 < end.x && end.x < 150.0;
            bool kou4 = 140.0 < end.y && end.y <200.0;
            bool kou5 = sumDistance < 350.0;

            bool tsuchi1 = -150.0 < start.x && start.x < 0.0;
            bool tsuchi2 = -80.0 < start.y && start.y < 140.0;
            bool tsuchi3 = 0.0 < end.x && end.x < 150.0;
            bool tsuchi4 = -80.0 < end.y && end.y < 140.0;
            bool tsuchi5 = sumDistance < 430.0;

            bool shi1 = -300.0 < start.x && start.x < -150.0;
            bool shi2 = -80.0 < start.y && start.y < 140.0;
            bool shi3 = 150.0 < end.x && end.x < 300.0;
            bool shi4 = -80.0 < end.y && end.y < 140.0;
            bool shi5 = sumDistance < 600.0;

            sumDistance = 0.0;

            if (ue1 & ue2 & ue3 & ue4 & ue5) //条件と比較
            {
                DataManager.Instance.isCorrect = 1;
                DataManager.Instance.isdivide = 1;
                DataManager.Instance.isScene = 1;
                return "上";
            }
            else if (kou1 & kou2 & kou3 & kou4 & kou5) //条件と比較
            {
                DataManager.Instance.isCorrect = 2;
                DataManager.Instance.isdivide = 1;
                DataManager.Instance.isScene = 1;
                return "工";
            }
            else if (tsuchi1 & tsuchi2 & tsuchi3 & tsuchi4 & tsuchi5) //条件と比較
            {
                DataManager.Instance.isCorrect = 3;
                DataManager.Instance.isdivide = 1;
                DataManager.Instance.isScene = 1;
                return "土";
            }
            else if (shi1 & shi2 & shi3 & shi4 & shi5) //条件と比較
            {
                DataManager.Instance.isCorrect = 4;
                DataManager.Instance.isdivide = 1;
                DataManager.Instance.isScene = 1;
                return "士";
            }
            else
            {
                DataManager.Instance.isFalse = 1;
                DataManager.Instance.isScene = 1;
                return "不正解";
            }

        }
    }
}