﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//爆風の炎を制御するクラス
public class Exprosion_fireO : MonoBehaviour
{
    private GameObject parent;    //親オブジェクト
    private GameObject grandma;   //親オブジェクトの親オブジェクト
    private Exprosion_O Exprosion;  //爆発をつかさどるクラス(経過時間とプレイヤー情報を参照する)

    private float power;          //爆弾の火力

    //炎の音を再生するため
    public AudioClip Fire;
    AudioSource audioSource;

    private bool fire;            //音を一度だけ流すため
    public bool exprosion;　　　　//壁に当たった時に炎を止めるため

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        grandma = parent.transform.parent.gameObject;
        Exprosion = grandma.GetComponent<Exprosion_O>();
        fire = true;
        exprosion = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        power = Exprosion.power;
        if (Exprosion.DeleteTime > 3 && fire)  //3秒後に炎の音が流れる
        {
            audioSource.PlayOneShot(Fire);
            fire = false;
        }

        if (Exprosion.DeleteTime < 3.5 && Exprosion.DeleteTime > 3 && exprosion)   //0.5秒で炎が伸びる
        {
            this.transform.localScale = new Vector3(1f, 1.8f * 4f * (Exprosion.DeleteTime - 3f) * power, 1f);
            this.transform.localPosition = new Vector3(0f, 2f * (Exprosion.DeleteTime - 3f), 0f);
        }
    }

    //壁やレンガに当たったら炎を止める
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kabe" || other.gameObject.tag == "Renga")
        {
            exprosion = false;
        }
    }
}
