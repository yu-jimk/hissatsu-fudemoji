using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Ju : MonoBehaviour
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
                        result = judgingJu();
                        Debug.Log(result);
                    }
                }
            }

            
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //十を判定
        string judgingJu(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool sen1 = -10.0 < start.x && start.x < 181.0;
                bool sen2 = 120.0 < start.y && start.y < 305.0;
                bool sen3 = -209.0 < end.x && end.x < -25.0;
                bool sen4 = 80.0 < end.y && end.y < 175.0;
                bool sen5 = start.y > end.y;
                bool sen6 = sumDistance < 370.0;

                bool tsuchi1 = -249.0 < start.x && start.x < -69.0;
                bool tsuchi2 = -200.0 < start.y && start.y < -19.0;
                bool tsuchi3 = 71.0 < end.x && end.x < 281.0;
                bool tsuchi4 = -200.0 < end.y && end.y < -29.0;
                bool tsuchi5 = sumDistance < 900.0;

                bool shi1 = -169.0 < start.x && start.x < 1.0;
                bool shi2 = -200.0 < start.y && start.y < -19.0;
                bool shi3 = 1.0 < end.x && end.x < 171.0;
                bool shi4 = -200.0 < end.y && end.y < -19.0;
                bool shi5 = sumDistance < 500.0;

                bool kan1 = -180.0 < start.x && start.x < -29.0;
                bool kan2 = 61.0 < start.y && start.y < 251.0;
                bool kan3 = 31.0 < end.x && end.x < 180.0;
                bool kan4 = 61.0 < end.y && end.y < 251.0;
                bool kan5 = sumDistance < 720.0;


                sumDistance = 0.0;

                if (sen1 & sen2 & sen3 & sen4 & sen5 & sen6) //条件と比較
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "千";
                } else if (tsuchi1 & tsuchi2 & tsuchi3 & tsuchi4 & tsuchi5)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "土";
                } else if (shi1 & shi2 & shi3 & shi4 & shi5)
                {
                    DataManager.Instance.isCorrect = 4;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "士";
                } else if (kan1 & kan2 & kan3 & kan4 & kan5)
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "干";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}