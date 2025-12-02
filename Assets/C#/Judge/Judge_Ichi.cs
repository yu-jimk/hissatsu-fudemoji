using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Ichi : MonoBehaviour
    {
        Vector3 start, end, beforeflame, nowflame; //宣言
        public Vector3 judgeObjTransform;
        private string result;
        double sumDistance = 0.0;
        int relaynana = 0;
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

                    //曲がりの判定ポイント
                    if (-119.0 < nowflame.x && nowflame.x < 0.0 && -200.0 < nowflame.y && nowflame.y < 10.0)
                    {
                        relaynana = 1;
                        Debug.Log("tootta");
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
                        result = judgingIchi();
                        Debug.Log(result);
                    }
                }
            }

            
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //一を判定
        string judgingIchi(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool juu1 = -80.0 < start.x && start.x < 81.0;
                bool juu2 = 71.0 < start.y && start.y < 261.0;
                bool juu3 = -80.0 < end.x && end.x < 81.0;
                bool juu4 = -209.0 < end.y && end.y < -19.0;
                bool juu5 = sumDistance < 500.0;

                bool ni11 = -269.0 < start.x && start.x < -119.0;
                bool ni12 = -249.0 < start.y && start.y < -30.0;
                bool ni13 = 135.0 < end.x && end.x < 291.0;
                bool ni14 = -249.0 < end.y && end.y < -30.0;
                bool ni15 = 114.0 < sumDistance && sumDistance < 600.0;

                bool ni21 = -179.0 < start.x && start.x < -30.0;
                bool ni22 = 30.0 < start.y && start.y < 261.0;
                bool ni23 = 5.0 < end.x && end.x < 163.0;
                bool ni24 = 30.0 < end.y && end.y < 261.0;
                bool ni25 = sumDistance < 460.0;

                bool tyou1 = -99.0 < start.x && start.x < 81.0;
                bool tyou2 = -40.0 < start.y && start.y < 30.0;
                bool tyou3 = -169.0 < end.x && end.x < 121.0;
                bool tyou4 = -300.0 < end.y && end.y < -49.0;
                bool tyou5 = sumDistance < 720.0;

                bool nana1 = -119.0 < start.x && start.x < 20.0;
                bool nana2 = 29.0 < start.y && start.y < 221.0;
                bool nana3 = 41.0 < end.x && end.x < 310.0;
                bool nana4 = -200.0 < end.y && end.y < 20.0;
                bool nana5 = sumDistance < 1000.0;
                bool nana6 = relaynana == 1;


                sumDistance = 0.0;

                if (juu1 & juu2 & juu3 & juu4 & juu5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "十";
                } else if (ni11 & ni12 & ni13 & ni14 & ni15)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "二";
                } else if (ni21 & ni22 & ni23 & ni24 & ni25)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "二";
                } else if (tyou1 & tyou2 & tyou3 & tyou4 & tyou5)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "丁";
                } else if (nana1 & nana2 & nana3 & nana4 & nana5 & nana6)
                {
                    DataManager.Instance.isCorrect = 4;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "七";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}