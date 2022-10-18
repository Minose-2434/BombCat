using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ゲーム全体をつかさどるクラス
public class GameMaster : MonoBehaviour
{
    public Text Text;          //画面に大きく出る文字
    public bool GameOver;      //プレイヤー1が負けたかを判定する
    public int player_num;     //プレイヤーの人数
    public static string winner;　//勝者の名前（リザルトシーンに渡す）
    private float Timer;       //経過時間主にゲームスタートに用いる

    //プレイヤー1～4のゲームオブジェクト
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    //プレイヤー1～4の行動を制御するクラス
    public Controller con1;
    public Computer con2;
    public Computer con3;
    public Computer con4;

    // Start is called before the first frame update
    void Start()
    {
        con1 = p1.GetComponent<Controller>();
        con2 = p2.GetComponent<Computer>();
        con3 = p3.GetComponent<Computer>();
        con4 = p4.GetComponent<Computer>();
        player_num = 4;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;  

        //始め3秒はカウントダウン
        if (Timer < 4)
        {
            GameStart(Timer);
        }

        //プレイヤー1ゲームオーバー時にテキストを表示
        if (GameOver)
        {
            Text.text = "Game Over";
        }

        //勝者が決まった時にwinnerに勝者を保存してリザルトシーンに移動
        if(player_num == 1)
        {
            if (con1.Game)
            {
                winner = "1p";
            }
            else if (con2.Game)
            {
                winner = "2p";
            }
            else if (con3.Game)
            {
                winner = "3p";
            }
            else if (con4.Game)
            {
                winner = "4p";
            }
            SceneManager.LoadScene("Result");
        }
    }

    //カウントダウを行う
    private void GameStart(float time)
    {
        if (time < 1)
        {
            Text.text = "3";
        }
        else if (time < 2)
        {
            Text.text = "2";
        }
        else if (time < 3)
        {
            Text.text = "1";
        }
        else if (time < 3.5)
        {
            //プレイヤー1～4を動けるようにする
            Text.text = "Start";
            con1.Game = true;
            con2.Game = true;
            con3.Game = true;
            con4.Game = true;
        }
        else
        {
            Text.text = "";
        }
    }
}
