using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//爆弾を生成するクラス
public class BombCreate : MonoBehaviour
{
    public bool touch;                //キャラクターが床の上にいるかどうかの判定
    public bool create;               //trueで爆弾を生成する

    //爆弾生成用のオブジェクト
    public GameObject BombObjPrefab;
    private GameObject BombsObj;

    private GameObject Player;       //プレイヤーまたはコンピューター
    private YukaScore YS;            //床のスコアにコンピューターが爆弾設置可能かの変数がある
    private Exprosion Exprosion;     //爆発のクラス(このクラスに爆弾を設置したプレイヤーの情報を送る)
    private Computer CPU;            //コンピューターの動きをつかさどるクラス
    private Controller Con;          //プレイヤーの動きを制御するクラス

    // Start is called before the first frame update
    void Start()
    {
        BombsObj = GameObject.Find("Bombs");
        Player = this.gameObject;
        YS = this.GetComponent<YukaScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.gameObject.tag == "Player_one")
        {
            if (Con.bomb && touch)  //プレイヤー1の場合左クリックで爆弾設置
            {
                create = true;
            }
        }
        else if(Player.gameObject.tag == "Player")
        {
            if (YS.bomb && touch)  //コンピューターの場合床スコアで設置可能であれば爆弾設置
            {
                create = true;
            }
        }

        //一定距離プレイヤーが床から離れたとき爆弾を生成する
        if (Mathf.Abs(Player.transform.position.x - this.transform.position.x) > 0.8f || Mathf.Abs(Player.transform.position.z - this.transform.position.z) > 0.8f)
        {  
            if (create)
            {
                if (Player.gameObject.tag == "Player_one")
                {
                    GameObject g = Instantiate(BombObjPrefab, BombsObj.transform);
                    g.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);  //床の真上に爆弾を生成
                    Exprosion = g.gameObject.GetComponent<Exprosion>();
                    //Eb.Player = Player;    //爆発用のクラスにプレイヤーの情報を送る
                    create = false;          //爆弾設置を不可に
                    touch = false;           //接触判定をfalseに
                    Con.bomb = false;　　　　//爆弾設置を不可に
                }    
                else if (Player.gameObject.tag == "Player")
                {
                    if (!CPU.setti)         //逃げ場がないとき
                    {
                        create = false;     //爆弾設置を不可に
                        YS.bomb = false;    //床スコアの設置も不可に
                    }
                    else
                    {
                        GameObject g = Instantiate(BombObjPrefab, BombsObj.transform);
                        g.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);  //床の真上に爆弾を生成
                        Exprosion = g.gameObject.GetComponent<Exprosion>();
                        //Eb.Player = Player;    //爆発用のクラスにプレイヤーの情報を送る
                        create = false;          //爆弾設置を不可に
                        touch = false;           //接触判定をfalseに
                    }
                }
            }
        }
        
    }

    //プレイヤーが離れたらtouchをfalseに
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player_one" || other.gameObject.tag == "Player")
        {
            touch = false;
        }
    }

    //プレイヤーが到着したらtouchをtrueにしてPlayerに情報を格納
    void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Player_one") 
        {
            touch = true;
            Player = other.gameObject;
            Con = Player.gameObject.GetComponent<Controller>();
        }
        else if (other.gameObject.tag == "Player")
        {
            touch = true;
            Player = other.gameObject;
            CPU = Player.gameObject.GetComponent<Computer>();
        }
    }
}
