using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameOverScript : MonoBehaviourPunCallbacks
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void BackToLobby()
    {
        Time.timeScale = 1;
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
        base.OnLeftRoom();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Disconnect()
    {
        Time.timeScale = 1; //have to unfreeze time here so photon can actually work
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Main Menu");
        base.OnDisconnected(cause);
    }

}
