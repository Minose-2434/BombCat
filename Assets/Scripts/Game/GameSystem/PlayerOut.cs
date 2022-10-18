using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//爆風に当たってしまった時の反応のためのクラス(プレイヤーとコンピューターそれぞれにアタッチされている)
public class PlayerOut : MonoBehaviour
{
    private Controller con;      //プレイヤーの動きの制御
    private Computer CPU;        //コンピューターの動きの制御
    public GameObject GameOver;  //ゲームオーバー時に薄暗くするためのオブジェクト
    public GameMaster GM;        //ゲームの進行をつかさどる
    private bool black;          //GameOverオブジェクトを1回だけ生成するために必要

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        black = true;

        //自身がプレイヤーかコンピューターかを見極める
        if (this.gameObject.tag == "Player_one")
        {
            con = this.GetComponent<Controller>();
        }
        else if(this.gameObject.tag == "Player")
        {
            CPU = this.GetComponent<Computer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //爆風に当たってしまった時
        if (other.gameObject.tag == "Fire")
        {
            if (this.gameObject.tag == "Player")  //自身がコンピューターのとき
            {
                this.gameObject.transform.position = new Vector3(5f, 13f, -0.5f);  　　　//上空に移動
                this.gameObject.transform.rotation = Quaternion.Euler(90f, 0.0f, 0.0f);  
                CPU.Game = false;  //動けないようにする
                if (black)
                {
                    GM.player_num -= 1;　//ゲームマスターのプレイヤー人数を1減らす
                    black = false;
                }
            }
            else if (this.gameObject.tag == "Player_one")  //自身がプレイヤーのとき
            {
                this.gameObject.transform.position = new Vector3(0, 13f, -0.5f);　　　　//上空に移動
                this.gameObject.transform.rotation = Quaternion.Euler(90f, 0.0f, 0.0f);
                GM.GameOver = true;  //ゲームマスターにゲームオーバーを伝える
                con.Game = false;    //動けないようにする
                if (black)
                {
                    //i度だけゲームオーバーオブジェクトを生成する
                    GameObject g = Instantiate(GameOver, this.transform);
                    g.transform.position = new Vector3(0, 10f, 0);
                    GM.player_num -= 1;  //ゲームマスターのプレイヤー人数を1減らす
                    black = false;
                }
            }
        }
    }
}
