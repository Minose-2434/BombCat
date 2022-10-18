using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//レンガに爆風が当たった時に消すクラス
public class RengaDelete : MonoBehaviour
{
    private YukaScore YS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //爆風に当たった時床のスコアをあげて自身は消える
        if (other.gameObject.tag == "Fire")
        {
            YS.score = 100;
            Destroy(this.gameObject);
        }
    }

    //自身の下にある床のスコアをつかさどるクラスを取得
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Yuka")
        {
            if (other.gameObject.transform.position.x == this.gameObject.transform.position.x && other.gameObject.transform.position.z == this.gameObject.transform.position.z)
            {
                YS = other.gameObject.GetComponent<YukaScore>();
            }
        }
    }
}
