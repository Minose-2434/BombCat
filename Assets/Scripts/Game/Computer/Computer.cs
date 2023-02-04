using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//コンピュータの動きを制御するクラス
public class Computer : MonoBehaviour
{
    private YukaScore YS;          //現在の床のスコアを参照する
    private YukaScore YS1;         //次の床のスコアを参照する
    private YukaScore YS2;         //次の床のスコアを参照する
    private GameObject Yuka;       //現在いる床(次の床に前の床ということを覚えさせる)
    public bool Game;              //ゲーム開始かどうか
    public bool arrive;            //目的地に到着したかどうか
    public bool setti;             //爆弾を設置することができるかどうか
    public float moveTime;         //動く時間(0.8秒で1つの動きをする)
    public Vector3 destination;    //目的地の座標を格納する
    public GameObject next;        //次の床

    public float transrateSpeed; //移動速度
    public float fire;           //爆弾の火力
    public int bomb_num;         //設置できる爆弾の個数

    //アニメーション制御用の変数
    private Animator animator;
    private int trans;

    //足音用の変数
    public AudioClip Foot;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transrateSpeed = 2.0f;
        fire = 1.0f;
        bomb_num = 1;
        audioSource = GetComponent<AudioSource>();
        destination = this.transform.position;
        setti = true;
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        trans = animator.GetInteger("trans");

        if (Game)   //ゲーム開始したら
        {
            moveTime += Time.deltaTime;
            arrive = ArriveDestination(this.gameObject, destination);
            if (moveTime < 0.5)   //0.5秒で次の目的地まで移動する
            {
                if (arrive)       //到着したら待機
                {
                    trans = 0;
                }
                else              //到着するまで目的地へ進む
                {
                    trans = 1;
                    this.transform.LookAt(destination);
                    this.transform.position += transform.forward * transrateSpeed * Time.deltaTime;
                }
            }
            else if (moveTime < 0.8)  //残り0.3秒で次の目的地を設定する
            {
                trans = 0;
                next = YS.next;
                destination = new Vector3(next.transform.position.x, this.transform.position.y, next.transform.position.z);     //目的地を次の床にする

                //次の床と次の次の床のスコアを参照して爆弾を設置するかどうかを判定する
                YS1 = YS.next.gameObject.GetComponent<YukaScore>();
                YS2 = YS1.next.gameObject.GetComponent<YukaScore>();
                YS1.before = Yuka;      //次の床に前の床を覚えさせる

                if (YS2.score > 99 && YS.score == 300)   //次の次の床に爆風が当たるとき設置を不可に
                {
                    if(YS2.gameObject != YS.gameObject && !YS.hundred)   //次の次の床と現在の床が違うときその場で待機
                    {
                        destination = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                    }
                    setti = false;
                }
                else if (YS1.score == 1 && YS.score == 300)  //次の床がレンガと隣接しているとき
                {
                    if (YS.next == YS.before)                //引き返すのならば設置できる
                    {
                        setti = true;
                    }
                    else                                     //そのまま進む時は行き止まりになるので設置を不可に
                    {
                        setti = false;
                    }
                }
                else       //それ以外の場合は設置できる
                {
                    setti = true;
                }
                //時間を0に戻して次の動きへ
                moveTime = 0;
            }            
        }
        animator.SetInteger("trans", trans);
    }

    //床に触れたらスコアとゲームオブジェクトを保存する
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Yuka")
        {
            YS = other.gameObject.GetComponent<YukaScore>();
            Yuka = other.gameObject;
        }
    }

    //目的地に到着したかどうかを判定する
    public bool ArriveDestination(GameObject my, Vector3 other)
    {
        if (Mathf.Abs(my.transform.position.x - other.x) < 0.1 && Mathf.Abs(my.transform.position.z - other.z) < 0.1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //足音を鳴らす
    public void PlayFootSound()
    {
        audioSource.PlayOneShot(Foot);
    }
}
