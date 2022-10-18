using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//爆発全般を制御するクラス
public class Exprosion : MonoBehaviour
{
    public GameObject bomb;   //爆弾本体のオブジェクト

    public float DeleteTime;  //爆発の時間管理に使う
    private bool exprosion;   //爆発エフェクトを一度だけ出すために使う

    private YukaScore YS;     //コンピュータの制御の際の床のスコア管理

    //爆発エフェクト用のオブジェクト
    public GameObject ExprosionObjPrefab;
    public GameObject ExprosionObj;

    //爆発音再生用
    public AudioClip Bomb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        exprosion = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DeleteTime += Time.deltaTime;   //爆弾生成されてからの経過時間

        if (DeleteTime > 3 && exprosion)    //三秒で爆発させる
        {
            audioSource.PlayOneShot(Bomb);  //爆発音を一度だけ流す
            Destroy(bomb);                  //爆弾を破裂したように見せる
            //爆発エフェクトを生成する
            GameObject g = Instantiate(ExprosionObjPrefab, ExprosionObj.transform);
            g.transform.position = this.transform.position;
            exprosion = false;　　//生成が一度だけになるようにする
        }
　　　　else if(DeleteTime > 6)
        {
            YS.bomb = false;　　　　　　//爆弾をいない判定に
            YS.proceed = true;          //進むことができるように
            Destroy(this.gameObject);   //爆弾を全て消す
        }
    }

    //触れた床のスコアを制御する
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Yuka")
        {
            YS = other.gameObject.GetComponent<YukaScore>();
        }
    }
}
