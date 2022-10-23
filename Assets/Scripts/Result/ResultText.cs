using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//リザルト画面のテキストを制御するクラス
public class ResultText : MonoBehaviour
{
    public Text Text;   //表示するテキスト

    // Start is called before the first frame update
    void Start()
    {
        Screen.lockCursor = false;                  //カーソルを表示

        //勝者であればYou Win!そうでなければYou Lose
        if (GameMaster.winner == "1p")
        {
            Text.text = "You Win!";
        }
        else
        {
            Text.text = "You Lose";
        }
    }
}
