using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//レンガに爆風が当たった時に消すクラス
public class RengaDelete_O : MonoBehaviourPunCallbacks
{
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
            if (photonView.IsMine)
            {
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
