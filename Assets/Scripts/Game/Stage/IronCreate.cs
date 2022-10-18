using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージの壊せないオブジェクトを生成するクラス
public class IronCreate : MonoBehaviour
{

    public GameObject IronObjPrefab;
    public GameObject IronsObj;

    void Awake()
    {
        for(int x=0; x<6; x++)
        {
            for(int z=0; z<5; z++)
            {
                GameObject g = Instantiate(IronObjPrefab, IronsObj.transform);
                g.transform.position = new Vector3((5f - (2f * x)), 0.5f, (4f - (2f * z)));
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
