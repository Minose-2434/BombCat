using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukaScore : MonoBehaviour
{
    private List<GameObject> YukaObjects = new List<GameObject>();  //四方のYukaオブジェクトを格納する
    private List<YukaScore> YSs = new List<YukaScore>();             //四方のYukaオブジェクトのスコアを格納する
    private YukaScore YS;          //次の目的地の内容を編集するため
    public int score;　　　　　　　//この数字を頼りに次の目的地が決まる
    public GameObject next;　　　　//次の目的地
    public GameObject before;　　　//どこから来たか

    private int min;      //最小値を保存する
    private int min_num;  //最小値のインデックス番号を保存する
    public bool proceed;　//進めるかどうかの判定(これがfalseだとスコアの更新をしない)
    private bool zero;    //レンガのある床と隣り合っているかの判定
    public bool hundred;  //爆弾のある床と隣り合っているかの判定
    public bool bomb;     //コンピューターが爆弾をおけるかの判定

    // Start is called before the first frame update
    void Start()
    {
        score = 1000;
        proceed = true;
    }

    // Update is called once per frame
    void Update()
    {
        zero = false;
        hundred = false;
        min = 1000;       //初期値設定

        //周りのスコアの最小値を求める
        for (int i = 0; i < YukaObjects.Count; i++)
        {
            if (YSs[i].score == 0)  //スコアが0の床に隣接する時その情報だけ残して次の目的地には設定しない
            {
                zero = true;
            }
            else if(YSs[i].score == 200)  //スコアが200(爆弾あり)の床と隣接するときその情報を残す
            {
                hundred = true;
            }
            else if (YSs[i].score < min && YSs[i].score >= 0)   //最小値を求める
            {
                min = YSs[i].score;
                min_num = i;
            }
        }

        //最小値や隣接する床の情報からスコアを設定する
        if (score != 0 && proceed && !bomb)   //スコアが0でない、壁がない、爆弾を設置しない時スコアを更新する
        {
            if (hundred)      //爆弾がある床が隣接する時スコアを100に
            {
                score = 100;
            }
            else if (zero)    //レンガがある床が隣接する時スコアを1に
            {
                score = 1;
            }
            else             //残りは最小値プラス1をする
            {
                score = min + 1;
            }
        }

        //次の目的地を設定する
        if(score != 0 && proceed)
        {
            if (min == 100)   //最小値が爆風がある時その場にとどまる
            {
                next = this.gameObject;
            }
            else
            {
                next = YukaObjects[min_num];
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //四方の床をYukaObjectsに保管
        if (other.gameObject.tag == "Yuka")
        {
            if(other.gameObject.transform.position.x == this.gameObject.transform.position.x || other.gameObject.transform.position.z == this.gameObject.transform.position.z)
            {
                YukaObjects.Add(other.gameObject);
                YSs.Add(other.gameObject.GetComponent<YukaScore>());
            }
        }

        //レンガが上にある時はスコアを0に
        if (other.gameObject.tag == "Renga")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x && other.gameObject.transform.position.z == this.gameObject.transform.position.z)
                score = 0;           
        }

        //壁が上にある時は進めないと判定スコアは初期値のまま
        if (other.gameObject.tag == "Kabe")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x && other.gameObject.transform.position.z == this.gameObject.transform.position.z)
                proceed = false;
        }

        //コンピューターが到着したときレンガと隣り合っているなら爆弾をおける
        if (other.gameObject.tag == "Player")
        {
            if (score == 1)
            {
                score = 300;
                bomb = true;
            }
        }

        //爆弾がある時は進めないスコアは200に
        if (other.gameObject.tag == "Bomb")
        {
            proceed = false;
            score = 200;
        }
    }
}
