using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//移動速度上昇のアイテムを取った時の処理
public class RunUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //ぶつかったオブジェクトがプレイヤーやコンピュータの時、移動速度を上昇させる
        if (other.gameObject.tag == "Player_one")
        {
            Controller con = other.gameObject.GetComponent<Controller>();
            if (con.transrateSpeed <= 5.0f)
            {
                con.transrateSpeed += 0.5f;
            }
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            ComputerMove con = other.gameObject.GetComponent<ComputerMove>();
            if (con._TransrateSpeed <= 5.0f)
            {
                con._TransrateSpeed += 0.5f;
            }
            Destroy(this.gameObject);
        }
    }
}
