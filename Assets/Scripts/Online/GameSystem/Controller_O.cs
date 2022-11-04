using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.IO;
using Photon.Pun;

//プレイヤーの動きを制御するクラス
public class Controller_O : MonoBehaviourPunCallbacks
{
    private Rigidbody rb;
    public bool Setti;           //地面に設置しているかどうか
    public bool bomb;            //爆弾を設置するかどうか
    public bool Rotate;          //ゲームオーバー時にfalseで回転不可能に
    public bool Game;            //trueでゲーム開始

    public float rotateSpeed;    //回転速度
    public float transrateSpeed; //移動速度
    public float fire;           //爆弾の火力
    public int bomb_num;         //設置できる爆弾の個数
    public bool punch;           //パンチが可能かどうか

    private Animator animator;
    private int trans;          //アニメーション制御の変数

    public AudioClip Foot;　　　//足音
    AudioSource audioSource;

    private List<KeyCode> key = new List<KeyCode>();   //キーコードを保存しておく配列
    public GameObject VRcamera;  //カメラ
    public GameObject Body;
    private bool block;         //壁に当たっているかどうか

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        rotateSpeed = 2.0f;
        transrateSpeed = 2.0f;
        fire = 1.0f;
        bomb_num = 1;
        punch = false;
        Rotate = true;
        bomb = false;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Game = true;
        VRcamera = GameObject.Find("CenterEyeAnchor");
        Body = GameObject.Find("Body");

        //保存してあるキー配置を設定する
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            key.Add(data.Zensin);
            key.Add(data.Koutai);
            key.Add(data.Migi);
            key.Add(data.Hidari);
            key.Add(data.Jamp);
            key.Add(data.Setti);
        }
        else
        {
            key.Add(KeyCode.E);
            key.Add(KeyCode.S);
            key.Add(KeyCode.D);
            key.Add(KeyCode.A);
            key.Add(KeyCode.Joystick2Button0);
            key.Add(KeyCode.Joystick2Button5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && Game)
        {
            animator = GetComponent<Animator>();
            trans = animator.GetInteger("trans");

            trans = 0;
            if (Input.GetKey(key[0]))  //前進
            {
                trans = 1;
                this.transform.position += this.transform.forward * transrateSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(key[1]))  //後退
            {
                trans = 1;
                this.transform.position -= this.transform.forward * transrateSpeed * Time.deltaTime;
            }
            if (Input.GetKey(key[2]))  //右
            {
                trans = 2;
                this.transform.position += this.transform.right * transrateSpeed / 2 * Time.deltaTime;
            }
            else if (Input.GetKey(key[3]))  //左
            {
                trans = 2;
                this.transform.position -= this.transform.right * transrateSpeed / 2 * Time.deltaTime;
            }

            if (Input.GetKeyDown(key[4])) //ジャンプ
            {
                trans = 3;
                if (Setti)　//地面についていたら
                {
                    Setti = false;　　//Settiをfalseにして
                    rb.AddForce(new Vector3(0, 200f, 0));　//ジャンプ
                }
            }

            if (Input.GetKeyDown(key[5]))   //爆弾を設置する
            {
                bomb = true;
            }

            if (Input.GetKeyUp(key[5]))
            {
                bomb = false;
            }

            /*
            if(punch && Input.GetKeyDown(KeyCode.E))  //パンチ
            {
                trans = 5;
            }*/

            if (Rotate)  //回転
            {
                rotateObject();
                VRrotate();
            }

            VRmove();

            animator.SetInteger("trans", trans);
        }
    }

    //VRを用いた移動
    private void VRmove()
    {
        Vector2 stick = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector3 forwardg = new Vector3(VRcamera.transform.forward.x, 0, VRcamera.transform.forward.z);
        Vector3 rightg = new Vector3(VRcamera.transform.right.x, 0, VRcamera.transform.right.z);
        this.transform.position += forwardg * stick.y * transrateSpeed * Time.deltaTime;
        this.transform.position += rightg * stick.x * transrateSpeed * Time.deltaTime;
        if(stick.x != 0 && stick.y != 0)
        {
            trans = 1;
        }
    }

    //VRを用いた回転
    private void VRrotate()
    {
        Vector2 stick = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick) * rotateSpeed;
        Vector3 VRcameraRotate = VRcamera.transform.eulerAngles;

        Body.transform.rotation = Quaternion.Euler(VRcameraRotate);
        this.transform.RotateAround(this.transform.position, Vector3.up, stick.x);
    }

    private void rotateObject()  //回転
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed / (-2.0f), 0);

        //transform.RotateAround()を使用してメインカメラを回転させる
        this.transform.RotateAround(this.transform.position, Vector3.up, angle.x);
        this.transform.RotateAround(this.transform.position, transform.right, angle.y);
    }

    void OnCollisionEnter(Collision other) //ジャンプ
    {
        if (other.gameObject.tag == "Yuka") //Yukaタグのオブジェクトに触れたとき
        {
            Setti = true; //Settiをtrueにする
        }
        if (other.gameObject.tag == "Kabe") //Yukaタグのオブジェクトに触れたとき
        {
            block = true; //blockをtrueにする
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Kabe") //Yukaタグのオブジェクトに触れたとき
        {
            block = false; //blockをfalseにする
        }
    }

    public void PlayFootSound()
    {
        audioSource.PlayOneShot(Foot);　　//一回音を鳴らす
    }
}
