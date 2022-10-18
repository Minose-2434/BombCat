using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove_O : MonoBehaviour
{
    public GameObject winner; //勝者のゲームオブジェクトを保存する
    private Animator animator;
    private int trans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster_O.winner == "Player1")        //勝者がプレーヤー1ならスポットライトをプレーヤー1のところへ
        {
            winner = GameObject.Find("Player1(Clone)");
            this.transform.position = new Vector3(winner.transform.position.x, 5f, -5f);
        }
        else if (GameMaster_O.winner == "Player2")   //勝者がプレーヤー2ならスポットライトをプレーヤー2のところへ
        {
            winner = GameObject.Find("Player2(Clone)");
            this.transform.position = new Vector3(winner.transform.position.x, 5f, -5f);
        }
        else if (GameMaster_O.winner == "Player3")   //勝者がプレーヤー3ならスポットライトをプレーヤー3のところへ
        {
            winner = GameObject.Find("Player3(Clone)");
            this.transform.position = new Vector3(winner.transform.position.x, 5f, -5f);
        }
        else if (GameMaster_O.winner == "Player4")   //勝者がプレーヤー4ならスポットライトをプレーヤー4のところへ
        {
            winner = GameObject.Find("Player4(Clone)");
            this.transform.position = new Vector3(winner.transform.position.x, 5f, -5f);
        }

        //勝者のアニメーションと動きを制御する
        animator = winner.GetComponent<Animator>();
        trans = animator.GetInteger("trans");

        winner.transform.position = new Vector3(winner.transform.position.x, 0f, -5f);
        trans = 3;
        animator.SetInteger("trans", trans);
    }
}
