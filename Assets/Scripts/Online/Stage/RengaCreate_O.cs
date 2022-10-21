using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//ステージの壊せるオブジェクトを生成するクラス
public class RengaCreate_O : MonoBehaviourPunCallbacks
{
    public GameObject RengasObj;
    public GameObject Item;
    public GameObject Kabe1;
    public GameObject Kabe2;
    public GameObject Kabe3;
    public GameObject Kabe4;
    public bool create;

    // Start is called before the first frame update
    void Start()
    {
        create = true;
    }

    //プレーヤー4人用のステージ生成
    public void Create4()
    {
        for (int z = 0; z < 7; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(6f, 3f - z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 6f, 3f - z);
                }
            }
            if(Random.value < 0.9)
            {
                rengaCreate(-6f, 3f - z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -6f, 3f - z);
                }
            }
        }

        for (int z = 0; z < 4; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(5f, 3f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 5f, 3f - 2 * z);
                }
            }
            if(Random.value < 0.9)
            {
                rengaCreate(-5f, 3f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -5f, 3f - 2 * z);
                }
            }
        }

        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 11; z++)
            {
                if (Random.value < 0.9)
                {
                    rengaCreate(4f - 2 * x, 5f - z);

                    if (Random.value < 0.5)
                    {
                        itemCreate(Random.Range(0, 3), 4f - 2 * x, 5f - z);
                    }
                }
            }
        }

        for (int x = 0; x < 4; x++)
        {
            for (int z = 0; z < 6; z++)
            {
                if (Random.value < 0.9)
                {
                    rengaCreate(3f - 2 * x, 5f - 2 * z);

                    if (Random.value < 0.5)
                    {
                        itemCreate(Random.Range(0, 3), 3f - 2 * x, 5f - 2 * z);
                    }
                }
            }
        }
         create = false;
    }

    //プレーヤー3人用のステージ生成
    public void Create3()
    {
        for (int z = 0; z < 5; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(6f, 3f - z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 6f, 3f - z);
                }
            }
            if (Random.value < 0.9)
            {
                rengaCreate(-6f, 3f - z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -6f, 3f - z);
                }
            }
        }

        for (int z = 0; z < 3; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(5f, 3f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 5f, 3f - 2 * z);
                }
            }
            if (Random.value < 0.9)
            {
                rengaCreate(-5f, 3f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -5f, 3f - 2 * z);
                }
            }
        }

        for (int x = 0; x < 2; x++)
        {
            for (int z = 0; z < 7; z++)
            {
                if (Random.value < 0.9)
                {
                    rengaCreate(2f + 2 * x, 3f - z);

                    if (Random.value < 0.5)
                    {
                        itemCreate(Random.Range(0, 3), 2f + 2 * x, 3f - z);
                    }
                }
                if (Random.value < 0.9)
                {
                    rengaCreate(-2f - 2 * x, 3f - z);

                    if (Random.value < 0.5)
                    {
                        itemCreate(Random.Range(0, 3), -2f - 2 * x, 3f - z);
                    }
                }
            }
        }

        for (int z = 0; z < 4; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(3f, 3f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 3f, 3f - 2 * z);
                }
            }
            if (Random.value < 0.9)
            {
                rengaCreate(-3f, 3f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -3f, 3f - 2 * z);
                }
            }
        }

        for (int z = 0; z < 3; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(1f, 1f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 1f, 1f - 2 * z);
                }
            }
            if (Random.value < 0.9)
            {
                rengaCreate(-1f, 1f - 2 * z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -1f, 1f - 2 * z);
                }
            }
        }

        for(int z = 0; z < 5; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(0f, 1f - z);

                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 0f, 1f - z);
                }
            }
        }
        create = false;
    }

    //プレーヤー2人用のステージ生成
    public void Create2()
    {
        for (int z = 0; z < 5; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(4f, 1f - z);
                
                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 4f, 1f - z);
                }
            }
            if (Random.value < 0.9)
            {
                rengaCreate(-4f, 3f - z);
                
                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -4f, 3f - z);
                }
            }
        }

        for (int z = 0; z < 3; z++)
        {
            if (Random.value < 0.9)
            {
                rengaCreate(3f, 1f - 2 * z);
                
                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), 3f, 1f - 2 * z);
                }
            }
            if (Random.value < 0.9)
            {
                rengaCreate(-3f, 3f - 2 * z);
                
                if (Random.value < 0.5)
                {
                    itemCreate(Random.Range(0, 3), -3f, 3f - 2 * z);
                }
            }
        }

        for (int x = 0; x < 3; x++)
        {
            for (int z = 0; z < 7; z++)
            {
                if (Random.value < 0.9)
                {
                    rengaCreate(2f - 2 * x, 3f - z);
                    
                    if (Random.value < 0.5)
                    {
                        itemCreate(Random.Range(0, 3), 2f - 2 * x, 3f - z);
                    }
                }
            }
        }

        for (int x = 0; x < 2; x++)
        {
            for (int z = 0; z < 4; z++)
            {
                if (Random.value < 0.9)
                {
                    rengaCreate(1f - 2 * x, 3f - 2 * z);   
                    
                    if (Random.value < 0.5)
                    {
                        itemCreate(Random.Range(0, 3), 1f - 2 * x, 3f - 2 * z);
                    }
                }
            }
        }
        create = false;
    }

    //アイテムを生成するメソッド
    private void itemCreate(int num, float x, float z)
    {
        if (num == 0)
        {
            GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(x, 0.15f, z), Quaternion.identity);
            item.transform.parent = Item.transform;
        }
        else if (num == 1)
        {
            GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(x, 0.15f,z), Quaternion.identity);
            item.transform.parent = Item.transform;
        }
        else if (num == 2)
        {
            GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(x, 0.15f,z), Quaternion.identity);
            item.transform.parent = Item.transform;
        }
    }

    //レンガを生成するメソッド
    private void rengaCreate(float x, float z)
    {
        GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(x, 0.5f, z), Quaternion.identity);
        renga.transform.parent = RengasObj.transform;
    }
}
