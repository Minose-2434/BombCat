using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunUp_O : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player_one")
        {
            Controller_O con = other.gameObject.GetComponent<Controller_O>();
            if(con.transrateSpeed <= 5.0f)
            {
                con.transrateSpeed += 0.5f;
            }
            Destroy(this.gameObject);
        }
    }
}
