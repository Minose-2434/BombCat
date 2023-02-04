using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//爆弾数増加のアイテムを取った時の処理
public class BombUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //ぶつかったオブジェクトがプレイヤーやコンピュータの時、設置できる爆弾数を増加させる
        if (other.gameObject.tag == "Player_one")
        {
            Controller con = other.gameObject.GetComponent<Controller>();
            if (con.bomb_num <= 8)
            {
                con.bomb_num += 1;
            }
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            ComputerMove con = other.gameObject.GetComponent<ComputerMove>();
            if (con._BombNum <= 8)
            {
                con._BombNum += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
