using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class Matching : MonoBehaviourPunCallbacks
{
    public GameObject camera;
    private void Start()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        //ルームの人数を把握する
        int num = PhotonNetwork.CurrentRoom.PlayerCount;

        //プレーヤーの順番に応じて対応するアバターを生成する
        if(num == 1)
        {
            var position = new Vector3(Random.Range(-6f,6f), 0.2f, Random.Range(-5f,5f));
            GameObject player = PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);
            camera.transform.parent = player.transform;
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4f * 0.16f, player.transform.position.z - 0.7f * 0.16f);
            PhotonNetwork.InstantiateRoomObject("GameMaster", Vector3.zero, Quaternion.identity);
        }
        else if (num == 2)
        {
            var position = new Vector3(Random.Range(-6f, 6f), 0.2f, Random.Range(-5f, 5f));
            GameObject player = PhotonNetwork.Instantiate("Player2", position, Quaternion.identity);
            camera.transform.parent = player.transform;
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4f * 0.16f, player.transform.position.z - 0.7f * 0.16f);
        }
        else if (num == 3)
        {
            var position = new Vector3(Random.Range(-6f, 6f), 0.2f, Random.Range(-5f, 5f));
            GameObject player = PhotonNetwork.Instantiate("Player3", position, Quaternion.identity);
            camera.transform.parent = player.transform;
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4f * 0.16f, player.transform.position.z - 0.7f * 0.16f);
        }
        else if (num == 4)
        {
            var position = new Vector3(Random.Range(-6f, 6f), 0.2f, Random.Range(-5f, 5f));
            GameObject player = PhotonNetwork.Instantiate("Player4", position, Quaternion.identity);
            camera.transform.parent = player.transform;
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4f * 0.16f, player.transform.position.z - 0.7f * 0.16f);
        }
    }
}
