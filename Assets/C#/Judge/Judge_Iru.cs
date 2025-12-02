using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
    public class Judge_Iru : MonoBehaviour
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
        // Start is called before the first frame update
        void Start()
        {
            DataManager.Instance.isCorrect = 0;
            DataManager.Instance.isFalse = 0;
            DataManager.Instance.isdivide = 0;
            DataManager.Instance.isScene = 0;
        }

        // Update is called once per frame
        void Update()
        {

            updateTransformData();
            //Debug.Log(judgeObjTransform);

            if (judgeObjTransform.z <= 0) //ドラッグしている間
            {
                //下がって最初の時
                if(isDownFirst == false){
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
            else{
                if(isUpFirst){
                    isUpFirst = false;
                    isDownFirst = false;
                    result = judgingIru();
                    Debug.Log(result);
                } 
            }
            
        }

        //オブジェクトの位置を更新
        void updateTransformData(){
            judgeObjTransform = this.gameObject.transform.position;
        }

        //冶を判定
        string judgingIru(){
                end = judgeObjTransform; //終了地点の座標を取得
                Debug.Log("終了" + end);
                nowflame = end;
                sumDistance = sumDistance + Vector3.Distance(beforeflame, nowflame);
            
                Debug.Log("長さ" + sumDistance);
                bool chi11 = -250.0 < start.x && start.x < -120.0;
                bool chi12 = -10.0 < start.y && start.y < 90.0;
                bool chi13 = -250.0 < end.x && end.x < -80.0;
                bool chi14 = 0.0 < end.y && end.y < 90.0;
                bool chi15 = sumDistance < 200.0;

                bool chi21 = -270.0 < start.x && start.x < -50.0;
                bool chi22 = 90.0 < start.y && start.y < 250.0;
                bool chi23 = -270.0 < end.x && end.x < -50.0;
                bool chi24 = 90.0 < end.y && end.y < 250.0;
                bool chi25 = sumDistance < 200.0;

            sumDistance = 0.0;

                if (chi11 & chi12 & chi13 & chi14 & chi15)
                {
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "治";
                }else if (chi21 & chi22 & chi23 & chi24 & chi25){
                    DataManager.Instance.isCorrect = 1;
                    DataManager.Instance.isdivide = 1;
                    DataManager.Instance.isScene = 1;
                    return "治";
                } else {
                    DataManager.Instance.isFalse = 1;
                    DataManager.Instance.isScene = 1;
                    return "不正解";
                }

        }
    }
}