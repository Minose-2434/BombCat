using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージの壊せないオブジェクトを生成するクラス
public class IronCreate_O : MonoBehaviour
{
    public GameObject IronObjPrefab;
    public GameObject IronsObj;
    public GameObject Kabe1;
    public GameObject Kabe2;
    public GameObject Kabe3;
    public GameObject Kabe4;

    //プレーヤー4人用のステージ生成
    public void Create4()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                GameObject g = Instantiate(IronObjPrefab, IronsObj.transform);
                g.transform.position = new Vector3((5f - (2f * x)), 0.5f, (4f - (2f * z)));
            }
        }
    }

    //プレーヤー3人用のステージ生成
    public void Create3()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                GameObject g = Instantiate(IronObjPrefab, IronsObj.transform);
                g.transform.position = new Vector3((5f - (2f * x)), 0.5f, (2f - (2f * z)));
            }
        }
        Kabe3.transform.localScale = new Vector3(11f, 1f, 1f);
        Kabe3.transform.position = new Vector3(0f, 0.5f, 4f);
        Kabe4.transform.localScale = new Vector3(11f, 1f, 1f);
        Kabe4.transform.position = new Vector3(0f, 0.5f, -4f);
    }

    //プレーヤー2人用のステージ生成
    public void Create2()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int z = 0; z < 3; z++)
            {
                GameObject g = Instantiate(IronObjPrefab, IronsObj.transform);
                g.transform.position = new Vector3((3f - (2f * x)), 0.5f, (2f - (2f * z)));
            }
        }
        Kabe1.transform.localScale = new Vector3(1f, 1f, 7f);
        Kabe1.transform.position = new Vector3(5f, 0.5f, 0f);
        Kabe2.transform.localScale = new Vector3(1f, 1f, 7f);
        Kabe2.transform.position = new Vector3(-5f, 0.5f, 0f);
        Kabe3.transform.localScale = new Vector3(11f, 1f, 1f);
        Kabe3.transform.position = new Vector3(0f, 0.5f, 4f);
        Kabe4.transform.localScale = new Vector3(11f, 1f, 1f);
        Kabe4.transform.position = new Vector3(0f, 0.5f, -4f);
    }
}
