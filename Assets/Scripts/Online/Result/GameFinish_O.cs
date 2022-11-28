using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameFinish_O : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Start");
        }
    }

    public void ClickFinishButton()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Start");
    }
}
