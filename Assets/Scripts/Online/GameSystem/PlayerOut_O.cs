using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerOut_O : MonoBehaviourPunCallbacks
{
    private Controller_O con;      //プレイヤーの動きの制御
    public GameObject GameOver;  //ゲームオーバー時に薄暗くするためのオブジェクト
    public GameMaster_O GM;      //ゲームの進行をつかさどる
    private bool black;          //GameOverオブジェクトを1回だけ生成するために必要

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameMaster(Clone)").GetComponent<GameMaster_O>();
        black = true;
        con = this.GetComponent<Controller_O>();
        if (photonView.IsMine)
        {
            GM.myname = this.gameObject.name;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //ゲーム開始して爆風に当たってしまった時
        if (other.gameObject.tag == "Fire" && GM.Timer > GM.StartTime)
        {
            if (photonView.IsMine)
            {
                photonView.RPC(nameof(GameOverPlayer), RpcTarget.All);
            }
        }
    }

    [PunRPC]
    private void GameOverPlayer()
    {
        this.gameObject.transform.position = new Vector3(4f - GM.player_num, 13f, -0.5f);    //上空に移動
        this.gameObject.transform.rotation = Quaternion.Euler(90f, 0.0f, 0.0f);
        con.Game = false;    //動けないようにする
        if (photonView.IsMine)
        {
            GM.GameOver = true;  //ゲームマスターにゲームオーバーを伝える
        }
        if (black)
        {
            //自身のオブジェクトの時1度だけゲームオーバーオブジェクトを生成する
            if (photonView.IsMine)
            {
                GameObject g = Instantiate(GameOver, this.transform);
                g.transform.position = new Vector3(0, 10f, 0);
            }
            GM.player_num -= 1;  //ゲームマスターのプレイヤー人数を1減らす
            black = false;
        }
    }
}
