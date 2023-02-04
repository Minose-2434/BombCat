using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージの壊せるオブジェクトを生成するクラス
public class RengaCreate : MonoBehaviour
{
    public GameObject RengaObjPrefab;  //レンガオブジェクトのプレハブ
    public GameObject RengasObj;       //レンガオブジェクトの親オブジェクト
    public GameObject FireUpObjPrefab; //爆弾の火力を上げるアイテム
    public GameObject BombUpObjPrefab; //設置可能な爆弾の数を増やすアイテム
    public GameObject RunUpObjPrefab;  //移動速度を上昇させるアイテム
    public GameObject ItemObj;         //各アイテムオブジェクトの親オブジェクト

    private enum ITEM_TYPE
    {
        FIRE_UP,
        BOMB_UP,
        RUN_UP,
    }

    private void Awake()
    {
        Create1();
        Create2();
        Create3();
        Create4();
    }

    //両端の生成動けるように一マスずつ空ける
    private void Create1()
    {
        for (int z = 0; z < 7; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(6f , 0.5f, 3f - z);
            //半分の確率でアイテム生成
            if (Random.value < 0.5)
            {
                ItemCreate(Random.Range(0, 3), 6f, 3f - z);
            }
        }
        for (int z = 0; z < 7; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(-6f, 0.5f, 3f - z);
            //半分の確率でアイテム生成
            if (Random.value < 0.5)
            {
                ItemCreate(Random.Range(0, 3), -6f, 3f - z);
            }
        }
    }

    //両端の一つ内側の生成動けるように一マスずつ空ける
    private void Create2()
    {
        for (int z = 0; z < 4; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(5f, 0.5f, 3f - 2 * z);
            //半分の確率でアイテム生成
            if (Random.value < 0.5)
            {
                ItemCreate(Random.Range(0, 3), 5f, 3f - 2 * z);
            }
        }
        for (int z = 0; z < 4; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(-5f, 0.5f, 3f - 2 * z);
            //半分の確率でアイテム生成
            if (Random.value < 0.5)
            {
                ItemCreate(Random.Range(0, 3), -5f, 3f - 2 * z);
            }
        }
    }

    //真ん中の偶数列を生成
    private void Create3()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 11; z++)
            {   //10%の確率で穴抜けに
                if (Random.value < 0.9)
                {   
                    GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
                    g.transform.position = new Vector3(4f - 2 * x, 0.5f, 5f - z);
                    //半分の確率でアイテム生成
                    if (Random.value < 0.5)
                    {
                        ItemCreate(Random.Range(0, 3), 4f - 2 * x, 5f - z);
                    }
                }
            }
        }
    }

    //真ん中の奇数列を生成
    private void Create4()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int z = 0; z < 6; z++)
            {   //10%の確率で穴抜けに
                if (Random.value < 0.9)
                {
                    GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
                    g.transform.position = new Vector3(3f - 2 * x, 0.5f, 5f - 2 * z);
                    //半分の確率でアイテム生成
                    if (Random.value < 0.5)
                    {
                        ItemCreate(Random.Range(0, 3), 3f - 2 * x, 5f - 2 * z);
                    }
                }
            }
        }
    }

    //アイテムを生成するメソッド
    private void ItemCreate(int num, float x, float z)
    {
        if (num == (int)ITEM_TYPE.FIRE_UP)
        {
            GameObject item = Instantiate(FireUpObjPrefab, ItemObj.transform);
            item.transform.position = new Vector3(x, 0.15f, z);
        }
        else if (num == (int)ITEM_TYPE.BOMB_UP)
        {
            GameObject item = Instantiate(BombUpObjPrefab, ItemObj.transform);
            item.transform.position = new Vector3(x, 0.15f, z);
        }
        else if (num == (int)ITEM_TYPE.RUN_UP)
        {
            GameObject item = Instantiate(RunUpObjPrefab, ItemObj.transform);
            item.transform.position = new Vector3(x, 0.15f, z);
        }
    }
}
