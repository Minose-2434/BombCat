using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//”š’e”‘‰Á‚ÌƒAƒCƒeƒ€‚ğæ‚Á‚½‚Ìˆ—
public class BombUp_O : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player_one")
        {
            Controller_O con = other.gameObject.GetComponent<Controller_O>();
            if(con.bomb_num <= 8)
            {
                con.bomb_num += 1;
            }
            Destroy(this.gameObject);
        }
    }
}
