using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Kou : MonoBehaviour
    {
        Vector3 start, end, beforeflame, nowflame; //宣言
        public Vector3 judgeObjTransform;
        private string result;
        double sumDistance = 0.0;
        int relaygo = 0;
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

                    //曲がるポイント
                    if (0.0 < nowflame.x && nowflame.x < 147.0 && -75.0 < nowflame.y && nowflame.y < 125.0)
                    {
                        relaygo = 1;
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
                        result = judgingKou();
                        Debug.Log(result);
                    }
                }
            }

            
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //工を判定
        string judgingKou(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool ou1 = -143.0 < start.x && start.x < 5.0;
                bool ou2 = -45.0 < start.y && start.y < 111.0;
                bool ou3 = -5.0 < end.x && end.x < 147.0;
                bool ou4 = -29.0 < end.y && end.y < 111.0;
                bool ou5 = sumDistance < 360.0;

                bool tsuchi1 = -60.0 < start.x && start.x < 60.0;
                bool tsuchi2 = 128.0 < start.y && start.y < 281.0;
                bool tsuchi3 = -60.0 < end.x && end.x < 60.0;
                bool tsuchi4 = -109.0 < end.y && end.y < 151.0;
                bool tsuchi5 = 70.0 < sumDistance && sumDistance < 600.0;

                bool kan1 = -60.0 < start.x && start.x < 60.0;
                bool kan2 = -103.0 < start.y && start.y < 151.0;
                bool kan3 = -60.0 < end.x && end.x < 60.0;
                bool kan4 = -275.0 < end.y && end.y < -130.0;
                bool kan5 = 100.0 < sumDistance && sumDistance < 680.0;

                bool go1 = -169.0 < start.x && start.x < 1.0;
                bool go2 = -69.0 < start.y && start.y < 111.0;
                bool go3 = -20.0 < end.x && end.x < 151.0;
                bool go4 = -113.0 < end.y && end.y < 30.0;
                bool go5 = sumDistance < 560.0;
                bool go6 = relaygo == 1;



                sumDistance = 0.0;

                if (ou1 & ou2 & ou3 & ou4 & ou5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "王";
                } else if (tsuchi1 & tsuchi2 & tsuchi3 & tsuchi4 & tsuchi5)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "土";
                } else if (kan1 & kan2 & kan3 & kan4 & kan5)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "干";
                } else if (go1 & go2 & go3 & go4 & go5 & go6)
                {
                    DataManager.Instance.isCorrect = 4;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "五";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}