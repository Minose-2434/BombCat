using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージの床を生成するクラス
public class YukaCreate : MonoBehaviour
{
    public GameObject Yuka_1ObjPrefab;  //濃い色の床
    public GameObject Yuka_2ObjPrefab;  //薄い色の床
    public GameObject YukasObj;

    void Awake()
    {
        for (int x = 0; x < 13; x++)
        {
            for (int z = 0; z < 11; z++)
            {
                if(x%2 == 0)
                {
                    if(z%2 == 0)
                    {
                        GameObject g = Instantiate(Yuka_1ObjPrefab, YukasObj.transform);
                        g.transform.position = new Vector3((6f-x), 0f, (5f-z));
                    }
                    else
                    {
                        GameObject g = Instantiate(Yuka_2ObjPrefab, YukasObj.transform);
                        g.transform.position = new Vector3((6f - x), 0f, (5f - z));
                    }
                }
                else
                {
                    if (z % 2 == 0)
                    {
                        GameObject g = Instantiate(Yuka_2ObjPrefab, YukasObj.transform);
                        g.transform.position = new Vector3((6f - x), 0f, (5f - z));
                    }
                    else
                    {
                        GameObject g = Instantiate(Yuka_1ObjPrefab, YukasObj.transform);
                        g.transform.position = new Vector3((6f - x), 0f, (5f - z));
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
