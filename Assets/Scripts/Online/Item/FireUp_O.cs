using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUp_O : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player_one")
        {
            Controller_O con = other.gameObject.GetComponent<Controller_O>();
            if (con.fire <= 8.0f)
            {
                con.fire += 1.0f;
            }
            Destroy(this.gameObject);
        }
    }
}
