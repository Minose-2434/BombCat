using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//爆弾を生成するクラス
public class BombCreate_O : MonoBehaviourPunCallbacks
{
    public bool touch;                //キャラクターが床の上にいるかどうかの判定
    public bool create;               //trueで爆弾を生成する

    //爆弾生成用のオブジェクト
    public GameObject BombObjPrefab;
    private GameObject BombsObj;

    private GameObject Player;       //プレイヤー
    private Exprosion_O Exprosion;   //爆発のクラス(このクラスに爆弾を設置したプレイヤーの情報を送る)
    private Controller_O Con;        //プレイヤーの動きを制御するクラス

    // Start is called before the first frame update
    void Start()
    {
        BombsObj = GameObject.Find("Bombs");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーオブジェクトが消えたら何もしない
        if (Player == null)
        {
            return;
        }

        if (Player.gameObject.tag == "Player_one")
        {
            if (Con.bomb && touch)  //プレイヤー1の場合左クリックで爆弾設置
            {
                create = true;
            }
        }

        //一定距離プレイヤーが床から離れたとき爆弾を生成する
        if (Mathf.Abs(Player.transform.position.x - this.transform.position.x) > 0.8f || Mathf.Abs(Player.transform.position.z - this.transform.position.z) > 0.8f)
        {
            if (create)
            {
                GameObject bomb = PhotonNetwork.Instantiate("Bomb", new Vector3(this.transform.position.x, 0.5f, this.transform.position.z), Quaternion.identity);  //床の真上に爆弾を生成
                bomb.transform.parent = BombsObj.transform;
                //Exprosion = bomb.gameObject.GetComponent<Exprosion_O>();
                //Eb.Player = Player;    //爆発用のクラスにプレイヤーの情報を送る
                create = false;          //爆弾設置を不可に
                touch = false;           //接触判定をfalseに
                Con.bomb = false;　　　　//爆弾設置を不可に
            }
        }
    }

    //プレイヤーが離れたらtouchをfalseに
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player_one")
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
            Con = Player.gameObject.GetComponent<Controller_O>();
        }
    }
}
