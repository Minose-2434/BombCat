using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//火力増加のアイテムを取った時の処理
public class FireUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //ぶつかったオブジェクトがプレイヤーやコンピュータの時、火力を増加させる
        if (other.gameObject.tag == "Player_one")
        {
            Controller con = other.gameObject.GetComponent<Controller>();
            if (con.fire <= 8.0f)
            {
                con.fire += 1.0f;
            }
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            ComputerMove con = other.gameObject.GetComponent<ComputerMove>();
            if (con._Fire <= 8.0f)
            {
                con._Fire += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
