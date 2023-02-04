using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour
{
    public GameObject _Player;
    private Controller _Con;
    private Text _Text;

    void Start()
    {
        _Con = _Player.GetComponent<Controller>();
        _Text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name == "FireText")
        {
            _Text.text = _Con.fire.ToString("F0");
        }
        else if (this.gameObject.name == "BombText")
        {
            _Text.text = _Con.bomb_num.ToString("F0");
        }
    }
}
