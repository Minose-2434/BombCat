using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//プレイヤーの動きを制御するクラス
public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    public bool Setti;           //地面に設置しているかどうか
    public bool bomb;            //爆弾を設置するかどうか
    public bool Rotate;          //ゲームオーバー時にfalseで回転不可能に
    public bool Game;            //trueでゲーム開始

    public float rotateSpeed;    //回転速度
    public float transrateSpeed; //移動速度

    private Animator animator;
    private int trans;          //アニメーション制御の変数

    public AudioClip Foot;　　　//足音
    AudioSource audioSource;

    private List<KeyCode> key = new List<KeyCode>();   //キーコードを保存しておく配列

    // Start is called before the first frame update
    private void Awake()
    {
        Screen.lockCursor = true;  // カーソルをウィンドウから出さない
    }

    void Start()
    {
        rotateSpeed = 2.0f;
        transrateSpeed = 2.0f;
        Rotate = true;
        bomb = false;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

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
            key.Add(KeyCode.Space);
            key.Add(KeyCode.Mouse0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Screen.lockCursor = false;  // エスケープボタンが押されたらカーソルを表示
        }

        animator = GetComponent<Animator>();
        trans = animator.GetInteger("trans");

        trans = 0;
        if (Game)
        {
            if (Input.GetKey(key[0]))  //前進
            {
                trans = 1;
                transform.position += transform.forward * transrateSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(key[1]))  //後退
            {
                trans = 1;
                transform.position -= transform.forward * transrateSpeed * Time.deltaTime;
            }
            if (Input.GetKey(key[2]))  //右
            {
                trans = 2;
                transform.position += transform.right * transrateSpeed / 2 * Time.deltaTime;
            }
            else if (Input.GetKey(key[3]))  //左
            {
                trans = 2;
                transform.position -= transform.right * transrateSpeed / 2 * Time.deltaTime;
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

            if(Input.GetKeyUp(key[5]))
            {
                bomb = false;
            }

            if (Rotate)  //回転
            {
                rotateObject();
            }
            animator.SetInteger("trans", trans);
        }
    }

    private void rotateObject()  //回転
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed / (-2.0f), 0);

        //transform.RotateAround()を使用してメインカメラを回転させる
        transform.RotateAround(this.transform.position, Vector3.up, angle.x);
        transform.RotateAround(this.transform.position, transform.right, angle.y);
    }

    void OnCollisionEnter(Collision other) //ジャンプ
    {
        if (other.gameObject.tag == "Yuka") //Yukaタグのオブジェクトに触れたとき
        {
            Setti = true; //Settiをtrueにする
        }
    }

    public void PlayFootSound()
    {
        audioSource.PlayOneShot(Foot);　　//一回音を鳴らす
    }
}
