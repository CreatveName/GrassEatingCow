using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;
    [SerializeField]
    private RoomItem roomItemPreFab;
    [SerializeField]
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    [SerializeField]
    private float nextUpdateTime;

    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    public GameObject playButton;
   
    
    private void Start()
    {
        PhotonNetwork.JoinLobby();
        nextUpdateTime = 0f;
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){ MaxPlayers = 4, BroadcastPropsChangeToAll = true});
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = " Room Name: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
        // Update function, might be the reason it goes we have the error since when this updates, highlight color might go back to null.
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach(RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPreFab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();
        
        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach(KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newplayerItem = Instantiate(playerItemPrefab, playerItemParent);
            
            newplayerItem.SetPlayerInfo(player.Value);
            
            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newplayerItem.ApplyLocalChanges();
                // Update function
            }
            
            playerItemsList.Add(newplayerItem);
        }
            
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient&& PhotonNetwork.CurrentRoom.PlayerCount>= 2)
        {

            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }
    public void OnClickPlayButton()
    {
        PhotonNetwork.LoadLevel("OnlineGame");
    }
}

