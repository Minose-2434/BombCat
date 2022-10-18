using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Settei : MonoBehaviour
{
    public GameObject Sousa;          //操作設定画面
    public GameObject System;         //システム設定画面
    public GameObject Change;         //キー変更の際に表示する画面
    public GameObject NotSave;        //セーブができない時に表示する画面
    public GameObject Cancel;         //キャンセルボタンを押した時に表示する画面
    public GameObject SousaButton;    //操作設定ボタン
    public GameObject SystemButton;   //システム設定ボタン
    public GameObject HozonButton;    //保存ボタン
    public GameObject CancelButton;   //キャンセルボタン
    public Text hozon;                //保存ボタンのテキスト
    public Text cancel;               //キャンセルボタンのテキスト
    private List<KeyCode> key = new List<KeyCode>();   //キーコードを保存しておく配列
    private bool save;                //キーコードに被りがないか判別する
    private bool henkou;              //キーコードに変更があるかを判別する
    private bool change;              //キーコードを変更する時に使う
    private int num;                  //キーコードを変更する際に配列の何番目を変更する

    //設定のボタンのテキスト
    public Text zensin;
    public Text koutai;
    public Text migi;
    public Text hidari;
    public Text jamp;
    public Text setti;

    public Slider BGMSound;          //BGMの音量設定スライダー
    public Slider SystemSound;       //システム音の音量設定スライダー

    //音量設定用のテキスト
    public Text bgm;                  
    public Text system;

    //BGMの音量を変更するのに必要
    public GameObject BGM;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        SousaButton.GetComponent<Image>().color = Color.yellow;
        audioSource = BGM.GetComponent<AudioSource>();
        save = true;
        henkou = false;
        change = false;

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            key.Add(data.Zensin);
            key.Add(data.Koutai);
            key.Add(data.Migi);
            key.Add(data.Hidari);
            key.Add(data.Jamp);
            key.Add(data.Setti);
            BGMSound.value = data.BGMSound;
            SystemSound.value = data.SystemSound;
        }
        else
        {
            key.Add(KeyCode.E);
            key.Add(KeyCode.S);
            key.Add(KeyCode.D);
            key.Add(KeyCode.A);
            key.Add(KeyCode.Space);
            key.Add(KeyCode.Mouse0);
            BGMSound.value = 1.0f;
            SystemSound.value = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        zensin.text = key[0].ToString();
        koutai.text = key[1].ToString();
        migi.text = key[2].ToString();
        hidari.text = key[3].ToString();
        jamp.text = key[4].ToString();
        setti.text = key[5].ToString();
        bgm.text = BGMSound.value.ToString();
        system.text = SystemSound.value.ToString();

        audioSource.volume = 0.1f * BGMSound.value;

        if (!save)
        {
            if (Input.anyKeyDown)
            {
                NotSave.transform.SetAsFirstSibling();
            }
        }

        if (change)
        {
            Change.transform.SetAsLastSibling();
            ChangeKey(num);
        }

        if (henkou)
        {
            HozonButton.GetComponent<Image>().color = Color.white;
            CancelButton.GetComponent<Image>().color = Color.white;
            hozon.text = "保存";
            cancel.text = "キャンセル";
        }
        else
        {
            HozonButton.GetComponent<Image>().color = Color.clear;
            CancelButton.GetComponent<Image>().color = Color.clear;
            hozon.text = "";
            cancel.text = "";
        }
    }

    //操作ボタンが押されたとき操作設定画面を最前面にしボタンの色を変える
    public void OnClickSousaButton()
    {
        SousaButton.GetComponent<Image>().color = Color.yellow;
        SystemButton.GetComponent<Image>().color = Color.white;
        Sousa.transform.SetAsLastSibling();
    }

    //システムボタンが押されたときシステム設定画面を最前面にしボタンの色を変える
    public void OnClickSystemButton()
    {
        SousaButton.GetComponent<Image>().color = Color.white;
        SystemButton.GetComponent<Image>().color = Color.yellow;
        System.transform.SetAsLastSibling();
    }

    //前進ボタンが押されたとき0番目のキーコードを変更する
    public void OnClickZensinButton()
    {
        num = 0;
        change = true;
    }

    //後退ボタンが押されたとき1番目のキーコードを変更する
    public void OnClicKoutaiButton()
    {
        num = 1;
        change = true;
    }

    //右ボタンが押されたとき2番目のキーコードを変更する
    public void OnClickMigiButton()
    {
        num = 2;
        change = true;
    }

    //左ボタンが押されたとき3番目のキーコードを変更する
    public void OnClickHidariButton()
    {
        num = 3;
        change = true;
    }

    //ジャンプボタンが押されたとき4番目のキーコードを変更する
    public void OnClickJampButton()
    {
        num = 4;
        change = true;
    }

    //設置ボタンが押されたとき5番目のキーコードを変更する
    public void OnClickSettiButton()
    {
        num = 5;
        change = true;
    }

    //保存ボタンが押されたときキーコードに被りがないか判別してなければセーブする
    public void OnClickSaveButton()
    {
        save = true;
        for(int i = 0; i < key.Count - 1; i++)
        {
            for(int j = i+1; j < key.Count; j++)
            {
                if(key[i] == key[j])
                {
                    save = false;
                }
            }
        }

        //セーブ可能であればセーブをし、不可能ならテキストを表示する
        if (save)
        {
            SaveSettei();
        }
        else
        {
            NotSave.transform.SetAsLastSibling();
        }
    }

    //キャンセルボタンが押されたとき確認画面を表示
    public void OnClickCancelButton()
    {
        Cancel.transform.SetAsLastSibling();
    }

    //キャンセルに同意したとき設定を元に戻す
    public void OnClickCancelYesButton()
    {
        Cancel.transform.SetAsFirstSibling();
        ResetSettei();
    }

    //キャンセルをしないとき確認画面を削除する
    public void OnClickCancelNoButton()
    {
        Cancel.transform.SetAsFirstSibling();
    }

    //戻るボタンを押したとき変更があれば破棄するか聞くなければそのままシーン移動
    public void OnClickModoruButton()
    {
        if (henkou)
        {
            Cancel.transform.SetAsLastSibling();
        }
        else
        {
            SceneManager.LoadScene("Start");
        }
    }

    //スライダーが動かされたとき保存ボタンとキャンセルボタンを出す
    public void SliderChange()
    {
        henkou = true;
    }

    //キーコードを変更する
    private void ChangeKey(int num)
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    key[num] = code;
                    Change.transform.SetAsFirstSibling();
                    henkou = true;
                    change = false;                   
                }
            }
        }
    }

    //設定をjson形式で保存する
    private void SaveSettei()
    {
        SaveData data = new SaveData();
        data.Zensin = key[0];
        data.Koutai = key[1];
        data.Migi = key[2];
        data.Hidari = key[3];
        data.Jamp = key[4];
        data.Setti = key[5];
        data.BGMSound = BGMSound.value;
        data.SystemSound = SystemSound.value;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        henkou = false;
    }

    //設定を元に戻す
    private void ResetSettei()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            key[0] = data.Zensin;
            key[1] = data.Koutai;
            key[2] = data.Migi;
            key[3] = data.Hidari;
            key[4] = data.Jamp;
            key[5] = data.Setti;
            BGMSound.value = data.BGMSound;
            SystemSound.value = data.SystemSound;
        }
        else
        {
            key[0] = KeyCode.E;
            key[1] = KeyCode.S;
            key[2] = KeyCode.D;
            key[3] = KeyCode.A;
            key[4] = KeyCode.Space;
            key[5] = KeyCode.Mouse0;
            BGMSound.value = 1.0f;
            SystemSound.value = 1.0f;
        }
        henkou = false;
    }
}
