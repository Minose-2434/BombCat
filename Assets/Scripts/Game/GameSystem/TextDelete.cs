using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームオーバー時にテキストと薄暗くするオブジェクトを削除するクラス
public class TextDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y > 5)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
