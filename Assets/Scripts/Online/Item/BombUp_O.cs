using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//爆弾数増加のアイテムを取った時の処理
public class BombUp_O : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player_one")
        {
            Controller_O con = other.gameObject.GetComponent<Controller_O>();
            if(con.bomb_num <= 8)
            {
                con.bomb_num += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
