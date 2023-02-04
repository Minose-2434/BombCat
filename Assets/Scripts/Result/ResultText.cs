using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//リザルト画面のテキストを制御するクラス
public class ResultText : MonoBehaviour
{
    public Text Text;   //表示するテキスト
    public AudioClip Win;　　　//勝利音
    public AudioClip Lose;　　//敗北音
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = false;                  //カーソルを表示
        audioSource = GetComponent<AudioSource>();

        //勝者であればYou Win!そうでなければYou Lose
        if (GameMaster.winner == "1p")
        {
            Text.text = "You Win!";
            audioSource.PlayOneShot(Win);　　//一回音を鳴らす
        }
        else
        {
            Text.text = "You Lose";
            audioSource.PlayOneShot(Lose);　　//一回音を鳴らす
        }
    }
}
