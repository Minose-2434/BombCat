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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
            PhotonNetwork.Disconnect();
        }
    }

    public void ClickFinishButton()
    {
        SceneManager.LoadScene("Start");
        PhotonNetwork.Disconnect();
    }
}
