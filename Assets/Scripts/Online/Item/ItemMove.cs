using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private float RotateSpeed;    //回転速度
    private float yr;             //角度
    private float MotionSpeed;    //運動速度
    private float yt;             //y座標
    private float Timer;          //経過時間

    // Start is called before the first frame update
    void Start()
    {
        RotateSpeed = 450;
        MotionSpeed = 0.2f;
        yt = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer < 0.4f)
        {
            yr += RotateSpeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0f, yr, 0f);
            yt += MotionSpeed * Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, yt, this.transform.position.z);
        }
        else if(Timer < 0.8f)
        {
            yr += RotateSpeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0f, yr, 0f);
            yt -= MotionSpeed * Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, yt, this.transform.position.z);
        }
        else if(Timer < 1.2f)
        {
            yt += MotionSpeed * Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, yt, this.transform.position.z);
        }
        else if (Timer < 1.6f)
        {
            yt -= MotionSpeed * Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, yt, this.transform.position.z);
        }
        else
        {
            Timer = 0;
            yr = 0;
        }
;    }
}
