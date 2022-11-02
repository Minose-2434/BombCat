using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{ 
    //プレハブ
    public GameObject player1;   //プレーヤー1を入れる
    public GameObject player2;   //プレーヤー2を入れる
    public GameObject player3;   //プレーヤー3を入れる
    public GameObject player4;   //プレーヤー4を入れる

    public Text win;            //勝敗を表示するテキスト

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの人数に応じてキャラクターを配置
        if(GameMaster_O.start_num == 2)
        {
            Instantiate(player1, new Vector3 (-1.5f,0f,5f), Quaternion.Euler(0f,180f,0));
            Instantiate(player2, new Vector3(1.5f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
        }
        else if(GameMaster_O.start_num == 3)
        {
            Instantiate(player1, new Vector3(-3f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
            Instantiate(player2, new Vector3(0f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
            Instantiate(player3, new Vector3(3f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
        }
        else if (GameMaster_O.start_num == 4)
        {
            Instantiate(player1, new Vector3(-4.5f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
            Instantiate(player2, new Vector3(-1.5f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
            Instantiate(player3, new Vector3(1.5f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
            Instantiate(player4, new Vector3(4.5f, 0f, 5f), Quaternion.Euler(0f, 180f, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Screen.lockCursor = false;   //画面内にカーソルを表示

        //自分が勝者であったらYou Win!!、敗者ならYou Lose
        if (GameMaster_O.winner + "(Clone)" == GameMaster_O.Myname)
        {
            win.text = "You Win!!";
        }
        else
        {
            win.text = "You Lose";
        }
    }
}
