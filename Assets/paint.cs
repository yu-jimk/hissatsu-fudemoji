//usingはc言語でいうところのinclude
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//public,privateは宣言の時につけるやつ
//下に書いてある色の話はvscodeでの場合の話
//緑は宣言時に使うintとかよくあるやつではないやつ
//青も宣言時に使うやつ　ただし、intみたいに良くあるやつ
//水色は変数名
//黄色が関数名

//宣言開始
public class paint : MonoBehaviour
 {
    [SerializeField]
    private RawImage m_image = null; //nullは０ですらないなんでもない空白 初期化として入れておくべきもの

    private Texture2D m_texture = null;

    [SerializeField]
    private int m_MaxThickness = 25;

    [SerializeField]
    private int m_minThickness = 10;

    private int Thickness;

    [SerializeField]
    private float m_thPlusRange = 0.3f;
    
    [SerializeField]
    private float m_thMinusRange = 0.5f;

//vector2は２変数（x、y）の座標をもつ変数の宣言に使うやつ
    private Vector2 m_prePos;
    private Vector2 m_TouchPosxxx;
   

    private int m_clickTimexxx, m_preClickTime;

    Vector2 BrushPos;
    bool IsTouch;

    int time;

    int WritingTime;

    int[] WritingDist = new int[5];

    int MaxwdAddress = 5;
    int wdAddress;

    private bool start = false;

    int isReset = 0;

    //宣言終了

//下１行追加(2021/11/23)
    private Vector2 m_disImagePos;

    public void OnDrag() //線を描画
    {
         // 押されているときの処理
        //以下１行修正(2021/11/23)
        m_TouchPosxxx = BrushPos - m_disImagePos; //現在のポインタの座標
        //m_TouchPos = _event.position; //現在のポインタの座標

        m_clickTimexxx = time; //最後にクリックイベントが送信された時間を取得

        float disTimexx = m_clickTimexxx - m_preClickTime; //前回のクリックイベントとの時差

        int width  = Thickness;  //ペンの太さ(ピクセル)
        int height = Thickness; //ペンの太さ(ピクセル)

        var dir  = m_prePos - m_TouchPosxxx; //直前のタッチ座標との差

        if(disTimexx > 1){
            dir = new Vector2(0,0); //0.1秒以上間隔があいたらタッチ座標の差を0にする
            WritingTime = 0;
            Thickness = m_minThickness;
            for(int i=0; i<MaxwdAddress; i++){
                WritingDist[i] = 0;
            }
        } 

        var dist = (int)dir.magnitude; //タッチ座標ベクトルの絶対値

        //WritingDist[wdAddress] = dist;
        var dist2 = dist;

        /*
        for(int i=0; i<MaxwdAddress; i++){
            dist2 += WritingDist[i];
        }
        */

        if(dist == 0){
            dist = 1;
        }

        //Debug.Log("Dist2 = "+dist2);

        dir = dir.normalized; //正規化

        if(dist2 != 0){
            WritingTime -= (int)dist2;
            if(WritingTime < 0){
                WritingTime = 0;
            }
        }

        //ペンの太さを扱うやつ
        if(Thickness <= m_MaxThickness){
            Thickness = m_minThickness + (int)(WritingTime*m_thPlusRange);
            WritingTime ++;
        }
        if(Thickness >= m_minThickness){
            Thickness -= (int)(dist2*m_thMinusRange);
        }

        if(Thickness < m_minThickness){
            Thickness = m_minThickness;
        }


        //指定のペンの太さ(ピクセル)で、前回のタッチ座標から今回のタッチ座標まで塗りつぶす
        for(int d = 0; d < dist; ++d)
        {
            var p_pos = m_TouchPosxxx + dir * d; //paint position
            p_pos.y -= height/2.0f;
            p_pos.x -= width/2.0f;
            //Debug.Log(p_pos);
            
            for ( int h = 0; h < height; ++h )
            {
                int y = (int)(p_pos.y + h);
                if ( y < 0 || y > m_texture.height ) continue; //タッチ座標がテクスチャの外の場合、描画処理を行わない

                for ( int w = 0; w < width; ++w )
                {
                    int x = (int)(p_pos.x + w);
                    if ( x >= 0 && x <= m_texture.width )
                    {
                        if ( Mathf.Sqrt(Mathf.Pow(x - (p_pos.x + width/2.0f), 2) + Mathf.Pow(y - (p_pos.y + height/2.0f), 2)) <= height/2.0f ){
                            if (start)
                            {
                                m_texture.SetPixel(x, y, Color.black); //線を描画
                            }
                        }
                    }
                }
            }
        }
        m_texture.Apply();
        m_prePos = m_TouchPosxxx;
        m_preClickTime = m_clickTimexxx;
        wdAddress ++;
        wdAddress = wdAddress%MaxwdAddress;
        start = true;

    }

    
//startはc言語のmain関数みたいなもの（このコードを実行した初めだけ動くプログラム）
    private void Start ()
    {
        var rect = m_image.gameObject.GetComponent<RectTransform>().rect;
        
        m_texture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);

        //下の行追加（2021/10/21）
        WhiteTexture((int)rect.width, (int)rect.height);

        m_image.texture = m_texture;

        //以下追加(2021/11/23)
        //ペイントエリアの指定
        var m_imagePos = m_image.gameObject.GetComponent<RectTransform>().anchoredPosition;
        m_disImagePos = new Vector2(m_imagePos.x - rect.width/2, m_imagePos.y - rect.height/2);

        time = 0;
        WritingTime = 0;
        Thickness = m_minThickness;
        wdAddress = 0;
        for(int i=0; i<MaxwdAddress; i++){
            WritingDist[i] = 0;
        }
    }

///以下6行７/８追加
    //マイフレーム毎に今いる座標をでバックログに表示（Updateはマイフレーム毎に実行されるプログラム）
    private void Update()
    {
        isReset = DataManager.Instance.isReset;

        //Debug.Log(m_prePos);
        BrushPos = this.GetComponent<brushHitBox>().BrushPos;
        IsTouch = this.GetComponent<brushHitBox>().IsTouch;
        //Debug.Log(IsTouch);
        if(IsTouch){
            OnDrag();
        }else{
            Thickness = m_minThickness;
        }
        if(isReset == 1){
            var rect = m_image.gameObject.GetComponent<RectTransform>().rect;
            WhiteTexture((int)rect.width, (int)rect.height);
            DataManager.Instance.isReset = 0;
        }
        time++;
    }

    //下の関数を追加（2021/10/21）
    //テクスチャを白色にする関数
    private void WhiteTexture(int width, int height)
    {
        for(int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                m_texture.SetPixel(w, h, Color.white);
            }
        }
        m_texture.Apply();
    }

}