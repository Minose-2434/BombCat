using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch_O : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player_one")
        {
            Controller_O con = other.gameObject.GetComponent<Controller_O>();
            con.punch = true;
            Destroy(this.gameObject);
        }
    }
}
