using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���e�������̃A�C�e������������̏���
public class BombUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        //�Ԃ������I�u�W�F�N�g���v���C���[��R���s���[�^�̎��A�ݒu�ł��锚�e���𑝉�������
        if (other.gameObject.tag == "Player_one")
        {
            Controller con = other.gameObject.GetComponent<Controller>();
            if (con.bomb_num <= 8)
            {
                con.bomb_num += 1;
            }
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            ComputerMove con = other.gameObject.GetComponent<ComputerMove>();
            if (con._BombNum <= 8)
            {
                con._BombNum += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
