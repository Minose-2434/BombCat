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
                GameObject renga_1 = PhotonNetwork.Instantiate("renga", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                renga_1.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if(Random.value < 0.9)
            {
                GameObject renga_2 = PhotonNetwork.Instantiate("renga", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                renga_2.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for (int z = 0; z < 4; z++)
        {
            if (Random.value < 0.9)
            {
                GameObject renga_1 = PhotonNetwork.Instantiate("renga", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                renga_1.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if(Random.value < 0.9)
            {
                GameObject renga_2 = PhotonNetwork.Instantiate("renga", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                renga_2.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 11; z++)
            {
                if (Random.value < 0.9)
                {
                    GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(4f - 2 * x, 0.5f, 5f - z), Quaternion.identity);
                    renga.transform.parent = RengasObj.transform;

                    if (Random.value < 0.5)
                    {
                        int number = Random.Range(0, 3);
                        if (number == 0)
                        {
                            GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(4f - 2 * x, 0.5f, 5f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 1)
                        {
                            GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(4f - 2 * x, 0.5f, 5f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 2)
                        {
                            GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(4f - 2 * x, 0.5f, 5f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
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
                    GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(3f - 2 * x, 0.5f, 5f - 2 * z), Quaternion.identity);
                    renga.transform.parent = RengasObj.transform;

                    if (Random.value < 0.5)
                    {
                        int number = Random.Range(0, 3);
                        if (number == 0)
                        {
                            GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(3f - 2 * x, 0.5f, 5f - 2 * z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 1)
                        {
                            GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(3f - 2 * x, 0.5f, 5f - 2 * z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 2)
                        {
                            GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(3f - 2 * x, 0.5f, 5f - 2 * z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
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
                GameObject renga_1 = PhotonNetwork.Instantiate("renga", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                renga_1.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if (Random.value < 0.9)
            {
                GameObject renga_2 = PhotonNetwork.Instantiate("renga", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                renga_2.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-6f, 0.5f, 3f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for (int z = 0; z < 3; z++)
        {
            if (Random.value < 0.9)
            {
                GameObject renga_1 = PhotonNetwork.Instantiate("renga", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                renga_1.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if (Random.value < 0.9)
            {
                GameObject renga_2 = PhotonNetwork.Instantiate("renga", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                renga_2.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-5f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for (int x = 0; x < 2; x++)
        {
            for (int z = 0; z < 7; z++)
            {
                if (Random.value < 0.9)
                {
                    GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(2f + 2 * x, 0.5f, 3f - z), Quaternion.identity);
                    renga.transform.parent = RengasObj.transform;

                    if (Random.value < 0.5)
                    {
                        int number = Random.Range(0, 3);
                        if (number == 0)
                        {
                            GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(2f + 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 1)
                        {
                            GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(2f + 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 2)
                        {
                            GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(2f + 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                    }
                }
                if (Random.value < 0.9)
                {
                    GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(-2f - 2 * x, 0.5f, 3f - z), Quaternion.identity);
                    renga.transform.parent = RengasObj.transform;

                    if (Random.value < 0.5)
                    {
                        int number = Random.Range(0, 3);
                        if (number == 0)
                        {
                            GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-2f + 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 1)
                        {
                            GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-2f + 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 2)
                        {
                            GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-2f + 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                    }
                }
            }
        }

        for (int z = 0; z < 4; z++)
        {
            if (Random.value < 0.9)
            {
                GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                renga.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if (Random.value < 0.9)
            {
                GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(-3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                renga.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for (int z = 0; z < 3; z++)
        {
            if (Random.value < 0.9)
            {
                GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                renga.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if (Random.value < 0.9)
            {
                GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(-1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                renga.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-1f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for(int z = 0; z < 5; z++)
        {
            if (Random.value < 0.9)
            {
                GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(0f, 0.5f, 1f - z), Quaternion.identity);
                renga.transform.parent = RengasObj.transform;

                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(0f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(0f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(0f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
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
                GameObject renga_1 = PhotonNetwork.Instantiate("renga", new Vector3(4f, 0.5f, 1f - z), Quaternion.identity);
                renga_1.transform.parent = RengasObj.transform;
                
                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(4f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(4f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(4f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if (Random.value < 0.9)
            {
                GameObject renga_2 = PhotonNetwork.Instantiate("renga", new Vector3(-4f, 0.5f, 3f - z), Quaternion.identity);
                renga_2.transform.parent = RengasObj.transform;
                
                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-4f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-4f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-4f, 0.5f, 1f - z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for (int z = 0; z < 3; z++)
        {
            if (Random.value < 0.9)
            {
                GameObject renga_1 = PhotonNetwork.Instantiate("renga", new Vector3(3f, 0.5f, 1f - 2 * z), Quaternion.identity);
                renga_1.transform.parent = RengasObj.transform;
                
                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(3f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(3f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(3f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
            if (Random.value < 0.9)
            {
                GameObject renga_2 = PhotonNetwork.Instantiate("renga", new Vector3(-3f, 0.5f, 3f - 2 * z), Quaternion.identity);
                renga_2.transform.parent = RengasObj.transform;
                
                if (Random.value < 0.5)
                {
                    int number = Random.Range(0, 3);
                    if (number == 0)
                    {
                        GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(-3f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 1)
                    {
                        GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(-3f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                    else if (number == 2)
                    {
                        GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(-3f, 0.5f, 1f - 2 * z), Quaternion.identity);
                        item.transform.parent = Item.transform;
                    }
                }
            }
        }

        for (int x = 0; x < 3; x++)
        {
            for (int z = 0; z < 7; z++)
            {
                if (Random.value < 0.9)
                {
                    GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(2f - 2 * x, 0.5f, 3f - z), Quaternion.identity);
                    renga.transform.parent = RengasObj.transform;
                    
                    if (Random.value < 0.5)
                    {
                        int number = Random.Range(0, 3);
                        if (number == 0)
                        {
                            GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(2f - 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 1)
                        {
                            GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(2f - 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 2)
                        {
                            GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(2f - 2 * x, 0.5f, 3f - z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
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
                    GameObject renga = PhotonNetwork.Instantiate("renga", new Vector3(1f - 2 * x, 0.5f, 3f - 2 * z), Quaternion.identity);
                    renga.transform.parent = RengasObj.transform;
                    
                    if (Random.value < 0.5)
                    {
                        int number = Random.Range(0, 3);
                        if (number == 0)
                        {
                            GameObject item = PhotonNetwork.Instantiate("FireUp", new Vector3(1f - 2 * x, 0.5f, 3f - 2 * z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 1)
                        {
                            GameObject item = PhotonNetwork.Instantiate("BombUp", new Vector3(1f - 2 * x, 0.5f, 3f - 2 * z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                        else if (number == 2)
                        {
                            GameObject item = PhotonNetwork.Instantiate("RunUp", new Vector3(1f - 2 * x, 0.5f, 3f - 2 * z), Quaternion.identity);
                            item.transform.parent = Item.transform;
                        }
                    }
                }
            }
        }
        create = false;
    }
}
