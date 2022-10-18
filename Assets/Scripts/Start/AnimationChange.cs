using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スタート画面のアニメーション制御をするクラス
public class AnimationChange : MonoBehaviour
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

        //それぞれのキャラクターを各々見栄えが良いように動かす
        if(this.gameObject.name == "1p")
        {
            trans = 1;
        }
        else if(this.gameObject.name == "2p")
        {
            trans = 0;
        }
        else if(this.gameObject.name == "3p")
        {
            trans = 4;
        }
        else if(this.gameObject.name == "4p")
        {
            trans = 3;
        }
        animator.SetInteger("trans", trans);
    }

    public void PlayFootSound()
    {

    }
}
