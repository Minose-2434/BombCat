using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//リザルト画面のアニメーション制御をするクラス
public class ResultAnime : MonoBehaviour
{
    //アニメーション制御に必要な変数
    private Animator animator;
    private int trans;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        trans = animator.GetInteger("trans");

        //勝者なら3のアニメーションそうでなければ0のアニメーション
        if (GameMaster.winner == this.gameObject.name)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0f, -5f);
            trans = 3;
        }
        else
        {
            trans = 0;
        }
        animator.SetInteger("trans", trans);
    }
}
