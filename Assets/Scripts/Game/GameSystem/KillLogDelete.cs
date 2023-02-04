using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キルログを消すためのクラス
public class KillLogDelete : MonoBehaviour
{
    private float _Timer;
    // Update is called once per frame
    void Update()
    {
        //2秒経ったら消す
        _Timer += Time.deltaTime;
        if(_Timer > 2)
        {
            Destroy(this.gameObject);
        }
    }
}
