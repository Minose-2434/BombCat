using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージの壊せるオブジェクトを生成するクラス
public class RengaCreate : MonoBehaviour
{
    public GameObject RengaObjPrefab;
    public GameObject RengasObj;

    private void Awake()
    {
        Create1();
        Create2();
        Create3();
        Create4();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Create1()
    {
        for (int z = 0; z < 7; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(6f , 0.5f, 3f - z);
        }
        for (int z = 0; z < 7; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(-6f, 0.5f, 3f - z);
        }
    }

    private void Create2()
    {
        for (int z = 0; z < 4; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(5f, 0.5f, 3f - 2 * z);
        }
        for (int z = 0; z < 4; z++)
        {
            GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
            g.transform.position = new Vector3(-5f, 0.5f, 3f - 2 * z);
        }
    }

    private void Create3()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 11; z++)
            {
                if (Random.value < 0.9)
                {
                    GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
                    g.transform.position = new Vector3(4f - 2 * x, 0.5f, 5f - z);
                }
            }
        }
    }

    private void Create4()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int z = 0; z < 6; z++)
            {
                if (Random.value < 0.9)
                {
                    GameObject g = Instantiate(RengaObjPrefab, RengasObj.transform);
                    g.transform.position = new Vector3(3f - 2 * x, 0.5f, 5f - 2 * z);
                }
            }
        }
    }
}
