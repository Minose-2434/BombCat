using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//爆発全般を制御するクラス
public class Exprosion_O : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject bomb;   //爆弾本体のオブジェクト

    public float DeleteTime;  //爆発の時間管理に使う
    private bool explosion;   //爆発エフェクトを一度だけ出すために使う

    public GameObject Player; //爆弾を生成したプレイヤーを保存

    //爆発エフェクト用のオブジェクト
    public GameObject ExplosionObj;
    public GameObject ExplosionObjPrefab;

    //爆発音再生用
    public AudioClip Bomb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        explosion = true;
        audioSource = GetComponent<AudioSource>();
        //ExplosionObj = this.transform.FindChild("Explosion").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DeleteTime += Time.deltaTime;   //爆弾生成されてからの経過時間

        if (DeleteTime > 3 && explosion)    //三秒で爆発させる
        {
            audioSource.PlayOneShot(Bomb);  //爆発音を一度だけ流す
            Destroy(bomb);                  //爆弾を破裂したように見せる
            //爆発エフェクトを生成する
            GameObject fire = Instantiate(ExplosionObjPrefab, ExplosionObj.transform);
            fire.transform.position = this.transform.position;
            explosion = false;　　//生成が一度だけになるようにする
        }
        else if (DeleteTime > 6)
        {
            Controller_O con = Player.gameObject.GetComponent<Controller_O>();
            con.bomb_num += 1;
            Destroy(this.gameObject);   //爆弾を全て消す
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Timerの値をストリームに書き込んで送信する
            stream.SendNext(Player);
        }
        else
        {
            // 受信したストリームを読み込んでTimerの値を更新する
            Player = (GameObject)stream.ReceiveNext();
        }
    }
}
