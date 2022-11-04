using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

//ゲーム全体をつかさどるクラス
public class GameMaster_O : MonoBehaviourPunCallbacks, IPunObservable
{
    public Text MainText;          //画面に大きく出る文字
    public Text SubText;          //画面の下に出る文字
    public bool GameOver;         //自プレイヤーが負けたかを判定する
    public bool game;             //ゲームスタートしたかの判定
    public int player_num;        //プレイヤーの人数
    public static int start_num;  //ゲーム開始時のプレイヤーの人数
    public static string winner; //勝者の名前（リザルトシーンに渡す）
    public float Timer;          //経過時間主にゲームスタートに用いる
    public float StartTime;      //ゲームがスタートした時間を保存する
    public string myname;        //自身の名前を保存する
    public static string Myname; //自身の名前Resultに送る
    private GameObject gameover; //ゲームオーバーの際に生成するオブジェクト

    public AudioClip StartSound; //ゲーム開始音
    AudioSource audioSource;     //AudioSource

    //ステージを生成するスクリプト
    public RengaCreate_O renga;
    public IronCreate_O iron;

    //プレイヤーキャラクターのゲームオブジェクト
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    //プレイヤー1～4の行動を制御するクラス
    public Controller_O con1;
    public Controller_O con2;
    public Controller_O con3;
    public Controller_O con4;

    // Start is called before the first frame update
    //初期化
    void Start()
    {
        Timer = 0;
        StartTime = 60;
        game = false;
        audioSource = GetComponent<AudioSource>();
        //保存してある音量設定を適用する
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            audioSource.volume = 0.5f * data.SystemSound;
        }
        else
        {
            audioSource.volume = 0.5f * 1.0f;
        }
        MainText = GameObject.Find("MainText").GetComponent<Text>();
        SubText = GameObject.Find("SubText").GetComponent<Text>();
        renga = GameObject.Find("Stage").GetComponent<RengaCreate_O>();
        iron = GameObject.Find("Stage").GetComponent<IronCreate_O>();
        Screen.lockCursor = true;  // カーソルをウィンドウから出さない
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Screen.lockCursor = false;  // エスケープボタンが押されたらカーソルを表示
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Screen.lockCursor = true;  // カーソルをウィンドウから出さない
        }

        //マッチングにかかった時間をマスタークライアントが計算する
        if (photonView.IsMine)
        {
            Timer += Time.deltaTime;
        }

        //プレーヤーの数を数え、キャラクターのゲームオブジェクトを取得
        if (Timer < StartTime /*&& !game*/)
        {
            player_num = PhotonNetwork.CurrentRoom.PlayerCount;
            p1 = GameObject.Find("Player1(Clone)");
            p2 = GameObject.Find("Player2(Clone)");
            p3 = GameObject.Find("Player3(Clone)");
            p4 = GameObject.Find("Player4(Clone)");

            SubText.text = "時間\n" + ((int)Timer).ToString() + "/"　+ StartTime.ToString();
            TextChange();
        }
        else if(Timer > StartTime /*|| player_num == 4*/)
        {
            if(!game)
            {
                StartTime = Timer;        //ゲームがスタートした時間を取得する
                start_num = player_num;   //ゲーム開始時の人数を取得する
                if(start_num != 1)
                {
                    audioSource.PlayOneShot(StartSound);  //プレイヤーが2人以上でゲームが始まるときカウントダウン音を鳴らす
                }
            }
            //photonView.RPC(nameof(GameStart), RpcTarget.All, StartTime, Timer);
            GameStart(StartTime, Timer);           
            SubText.text = "";

            //プレイヤー1ゲームオーバー時にテキストを表示
            if (GameOver)
            {
                MainText.text = "Game Over";
                gameover = GameObject.Find("GameOver(Clone)");

            }

            //勝者が決まった時にwinnerに勝者を保存してリザルトシーンに移動
            if (player_num == 1 && start_num != 1)
            {
                if (con1.Game)
                {
                    winner = "Player1";
                }
                else if (con2.Game)
                {
                    winner = "Player2";
                }
                else if (con3.Game)
                {
                    winner = "Player3";
                }
                else if (con4.Game)
                {
                    winner = "Player4";
                }
                Myname = myname;
                SceneManager.LoadScene("ResultOnline");
            }
        }
    }

    //プレイヤーを所定の位置に移動し、カウントダウンを行う
    private void GameStart(float start, float time)
    {
        if(player_num == 2 && renga.create)
        {
            con1 = p1.GetComponent<Controller_O>();
            con2 = p2.GetComponent<Controller_O>();
            con1.Game = false;
            con2.Game = false;
            p1.transform.position = new Vector3(-4f, 3f, -3f);
            p1.transform.rotation = Quaternion.identity;
            p2.transform.position = new Vector3(4f, 3f, 3f);
            p2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            iron.Create2();
            if (PhotonNetwork.IsMasterClient)
            {
                renga.Create2();
            }
            else
            {
                renga.create = false;
            }
            game = true;
        }
        else if(player_num == 3 && renga.create)
        {
            con1 = p1.GetComponent<Controller_O>();
            con2 = p2.GetComponent<Controller_O>();
            con3 = p3.GetComponent<Controller_O>();
            con1.Game = false;
            con2.Game = false;
            con3.Game = false;
            p1.transform.position = new Vector3(-6f, 3f, -3f);
            p1.transform.rotation = Quaternion.identity;
            p2.transform.position = new Vector3(6f, 3f, -3f);
            p2.transform.rotation = Quaternion.identity;
            p3.transform.position = new Vector3(0f, 3f, 3f);
            p3.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            iron.Create3();
            if (PhotonNetwork.IsMasterClient)
            {
                renga.Create3();
            }
            else
            {
                renga.create = false;
            }
            game = true;
        }
        else if (player_num == 4 && renga.create)
        {
            con1 = p1.GetComponent<Controller_O>();
            con2 = p2.GetComponent<Controller_O>();
            con3 = p3.GetComponent<Controller_O>();
            con4 = p4.GetComponent<Controller_O>();
            con1.Game = false;
            con2.Game = false;
            con3.Game = false;
            con4.Game = false;
            p1.transform.position = new Vector3(-6f, 3f, -5f);
            p1.transform.rotation = Quaternion.identity;
            p2.transform.position = new Vector3(6f, 3f, 5f);
            p2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            p3.transform.position = new Vector3(6f, 3f, -5f);
            p3.transform.rotation = Quaternion.identity;
            p4.transform.position = new Vector3(-6f, 3f, 5f);
            p4.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            iron.Create4();
            if (PhotonNetwork.IsMasterClient)
            {
                renga.Create4();
            }
            else
            {
                renga.create = false;
            }
            game = true;
        }
        else if(player_num == 1 && start_num == 1)
        {
            Timer = 0;
            StartTime = 60;
            return;
        }

        if (time - start < 1)
        {
            MainText.text = "3";
        }
        else if (time - start < 2)
        {
            MainText.text = "2";
        }
        else if (time - start < 3)
        {
            MainText.text = "1";
        }
        else if (time - start < 3.5)
        {
            //プレイヤー1～4を動けるようにする
            MainText.text = "Start";

            if (player_num == 2)
            {
                con1.Game = true;
                con2.Game = true;
            }
            else if (player_num == 3)
            {
                con1.Game = true;
                con2.Game = true;
                con3.Game = true;
            }
            else if (player_num == 4)
            {
                con1.Game = true;
                con2.Game = true;
                con3.Game = true;
                con4.Game = true;
            }
        }
        else
        {
            MainText.text = "";
        }
    }

    private void TextChange()
    {
        if((int)Timer % 3 == 0)
        {
            MainText.text = "マッチメイキング中.";
        }
        else if ((int)Timer % 3 == 1)
        {
            MainText.text = "マッチメイキング中..";
        }
        else if ((int)Timer % 3 == 2)
        {
            MainText.text = "マッチメイキング中...";
        }
    }

    //変数を同期する
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Timerの値をストリームに書き込んで送信する
            stream.SendNext(Timer);
        }
        else
        {
            // 受信したストリームを読み込んでTimerの値を更新する
            Timer = (float)stream.ReceiveNext();
        }
    }
}
