using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Ni : MonoBehaviour
    {
        Vector3 start, end, beforeflame, nowflame; //宣言
        public Vector3 judgeObjTransform;
        private string result;
        double sumDistance = 0.0;
        int relayyo1 = 0, relayyo2 = 0, relayotsu1 = 0, relayotsu2 = 0;
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

                    //曲がる判定のポイント
                    if (-150 < nowflame.x && nowflame.x < -90.0 && -70.0 < nowflame.y && nowflame.y < 65.0)
                    {
                        relayyo1 = 1;
                    }

                    if (-30.0 < nowflame.x && nowflame.x < 111.0 && -70.0 < nowflame.y && nowflame.y < 65.0 && relayyo1 == 1)
                    {
                        relayyo2 = 1;
                    }

                    if (40.0 < nowflame.x && nowflame.x < 120.0 && 40.0 < end.y && end.y < 110.0)
                    {
                        relayotsu1 = 1;
                        Debug.Log("乙1中継点" );
                    }

                    if (-129.0 < nowflame.x && nowflame.x < -59.0 && -89.0 < end.y && end.y < -9.0 && relayotsu1 == 1)
                    {
                        relayotsu2 = 1;
                        Debug.Log("乙2中継点");
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
                        result = judgingNi();
                        Debug.Log(result);
                    }
                }
            }

            
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //二を判定
        string judgingNi(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool kou1 = -50.0 < start.x && start.x < 50.0;
                bool kou2 = 70.0 < start.y && start.y < 130.0;
                bool kou3 = -50.0 < end.x && end.x < 50.0;
                bool kou4 = -93.0 < end.y && end.y < 0.0;
                bool kou5 = sumDistance < 300.0;

                bool san11 = -200.0 < start.x && start.x < -50.0;
                bool san12 = 100.0 < start.y && start.y < 250.0;
                bool san13 = 50.0 < end.x && end.x < 200.0;
                bool san14 = 100.0 < end.y && end.y < 250.0;
                bool san15 = sumDistance < 600.0;

                bool san21 = -139.0 < start.x && start.x < 20.0;
                bool san22 = -45.0 < start.y && start.y < 115.0;
                bool san23 = -30.0 < end.x && end.x < 141.0;
                bool san24 = -45.0 < end.y && end.y < 115.0;
                bool san25 = sumDistance < 400.0;

                bool kan1 = -60.0 < start.x && start.x < 40.0;
                bool kan2 = 70.0 < start.y && start.y < 125.0;
                bool kan3 = -60.0 < end.x && end.x < 40.0;
                bool kan4 = -249.0 < end.y && end.y < -93.0;
                bool kan5 = sumDistance < 450.0;

                bool tsuchi1 = -60.0 < start.x && start.x < 40.0;
                bool tsuchi2 = 90.0 < start.y && start.y < 261.0;
                bool tsuchi3 = -60.0 < end.x && end.x < 40.0;
                bool tsuchi4 = -93.0 < end.y && end.y < 10.0;
                bool tsuchi5 = sumDistance < 450.0;

                bool yo1 = -169.0 < start.x && start.x < -30.0;
                bool yo2 = 61.0 < start.y && start.y < 291.0;
                bool yo3 = -159.0 < end.x && end.x < 171.0;
                bool yo4 = -200.0 < end.y && end.y < -19.0;
                bool yo5 = sumDistance < 900.0;
                bool yo6 = relayyo1 == 1;
                bool yo7 = relayyo2 == 1;

                bool otsu11 = -140.0 < start.x && start.x < -10.0;
                bool otsu12 = 40.0 < start.y && start.y < 110.0;
                bool otsu13 = -210.0 < end.x && end.x < -182.0;
                bool otsu14 = -110.0 < end.y && end.y < 40.0;
                bool otsu15 = sumDistance < 800.0; 
                


                //bool otsu21 = -30.0 < start.x && start.x < 201.0;
                //bool otsu22 = 70.0 < start.y && start.y < 131.0;
                //bool otsu23 = 1.0 < end.x && end.x < 171.0;
                //bool otsu24 = -119.0 < end.y && end.y < 91.0;
                //bool otsu25 = sumDistance < 800.0;
                bool otsu26 = relayotsu1 == 1;
                bool otsu27 = relayotsu2 == 1;


            sumDistance = 0.0;

                if (kou1 & kou2 & kou3 & kou4 & kou5) //条件と比較
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "工";
                } else if (san11 & san12 & san13 & san14 & san15)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "三";
                } else if (san21 & san22 & san23 & san24 & san25)
                {
                    DataManager.Instance.isCorrect = 2;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "三";
                } else if (kan1 & kan2 & kan3 & kan4 & kan5)
                {
                    DataManager.Instance.isCorrect = 3;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "干";
                } else if (tsuchi1 & tsuchi2 & tsuchi3 & tsuchi4 & tsuchi5)
                {
                    DataManager.Instance.isCorrect = 4;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "土";
                } else if (yo1 & yo2 & yo3 & yo4 & yo5 & yo6 & yo7)
                {
                    DataManager.Instance.isCorrect = 5;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "与";
                } else if (otsu11 & otsu12 & otsu13 & otsu14 & otsu15 & otsu26 & otsu27) 
                {
                    DataManager.Instance.isCorrect = 6;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "乙";
                }// else if (otsu21 & otsu22 & otsu23 & otsu24 & otsu25 & otsu26)
                //{
                //    DataManager.Instance.isCorrect = 6;
                //    DataManager.Instance.isdivide = 1;
                //    DataManager.Instance.isScene = 1;
                //    return "乙";
                //} 
                else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}