using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�L�����O���������߂̃N���X
public class KillLogDelete : MonoBehaviour
{
    private float _Timer;
    // Update is called once per frame
    void Update()
    {
        //2�b�o���������
        _Timer += Time.deltaTime;
        if(_Timer > 2)
        {
            Destroy(this.gameObject);
        }
    }
}
