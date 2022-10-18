using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//リザルト画面のスポットライトを当てる部分を制御するクラス
public class LightMove : MonoBehaviour
{
    public GameObject p1;   //プレーヤー1を入れる
    public GameObject p2;   //プレーヤー2を入れる
    public GameObject p3;   //プレーヤー3を入れる
    public GameObject p4;   //プレーヤー4を入れる

    // Start is called before the first frame update
    void Start()
    {
        if (GameMaster.winner == "1p")        //勝者がプレーヤー1ならスポットライトをプレーヤー1のところへ
        {
            this.transform.position = new Vector3(p1.transform.position.x, 5f, -5f);
        }
        else if (GameMaster.winner == "2p")   //勝者がプレーヤー2ならスポットライトをプレーヤー2のところへ
        {
            this.transform.position = new Vector3(p2.transform.position.x, 5f, -5f);
        }
        else if (GameMaster.winner == "3p")   //勝者がプレーヤー3ならスポットライトをプレーヤー3のところへ
        {
            this.transform.position = new Vector3(p3.transform.position.x, 5f, -5f);
        }
        else if (GameMaster.winner == "4p")   //勝者がプレーヤー4ならスポットライトをプレーヤー4のところへ
        {
            this.transform.position = new Vector3(p4.transform.position.x, 5f, -5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
