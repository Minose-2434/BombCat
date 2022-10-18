using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//シーンを移動させるクラス
public class SceneChange : MonoBehaviour
{
    private float Timer;     //ボタンの点滅用の時間
    private bool Scene_O;    //オンラインプレイボタンを押したかの判定
    private bool Scene_G;    //ソロプレイボタンを押したかの判定
    private bool Scene_S;    //設定ボタンを押したかの判定
    public Text Game;        //ボタンのテキスト

    //ボタンを押したときの音
    public AudioClip button;
    AudioSource audioSource;
    private float volume;

    // Start is called before the first frame update
    void Start()
    {
        Scene_G = false;
        Scene_S = false;
        Timer = 0;
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
    }

    // Update is called once per frame
    void Update()
    {
        //オンラインプレイボタンが押されたら点滅させてシーン移動
        if (Scene_O)
        {
            Timer += Time.deltaTime;
            OnlinePlay();
        }

        //ソロプレイボタンが押されたら点滅させてシーン移動
        if (Scene_G)
        {
            Timer += Time.deltaTime;
            GameStart();
        }

        //設定ボタンが押されたら点滅させてシーン移動
        if (Scene_S)
        {
            Timer += Time.deltaTime;
            Settei();
        }
    }

    //オンラインプレイボタンが押されたらScene_Sをtrueにして音を鳴らす
    public void ClickOnlineButton()
    {
        Scene_O = true;
        audioSource.PlayOneShot(button);
    }

    //ソロプレイボタンが押されたらScene_Gをtrueにして音を鳴らす
    public void ClickStartButton()
    {
        Scene_G = true;
        audioSource.PlayOneShot(button);
    }

    //設定ボタンが押されたらScene_Sをtrueにして音を鳴らす
    public void ClickSettingButton()
    {
        Scene_S = true;
        audioSource.PlayOneShot(button);
    }

    private void OnlinePlay()
    {
        //0.1秒ごとに点滅させて1秒後にシーン移動
        if (Timer < 0.1)
        {
            Game.text = "";
        }
        else if (Timer < 0.2)
        {
            Game.text = "Online Play";
        }
        else if (Timer < 0.3)
        {
            Game.text = "";
        }
        else if (Timer < 0.4)
        {
            Game.text = "Online Play";
        }
        else if (Timer > 1)
        {
            SceneManager.LoadScene("Online");
        }
    }

    private void GameStart()
    {
        //0.1秒ごとに点滅させて1秒後にシーン移動
        if (Timer < 0.1)
        {
            Game.text = "";
        }
        else if (Timer < 0.2)
        {
            Game.text = "Solo Play";
        }
        else if (Timer < 0.3)
        {
            Game.text = "";
        }
        else if (Timer < 0.4)
        {
            Game.text = "Solo Play";
        }
        else if (Timer > 1)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void Settei()
    {
        //0.1秒ごとに点滅させて1秒後にシーン移動
        if (Timer < 0.1)
        {
            Game.text = "";
        }
        else if (Timer < 0.2)
        {
            Game.text = "Setting";
        }
        else if (Timer < 0.3)
        {
            Game.text = "";
        }
        else if (Timer < 0.4)
        {
            Game.text = "Setting";
        }
        else if (Timer > 1)
        {
            SceneManager.LoadScene("Setting");
        }
    }
}
