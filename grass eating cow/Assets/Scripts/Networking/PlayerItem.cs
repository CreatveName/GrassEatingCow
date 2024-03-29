using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text playerName;

    Image backgroundImage;
    [SerializeField]
    private GameObject LeftArrowButton;
    [SerializeField]
    private GameObject RightArrowButton;
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    [SerializeField]
    private Image playerAvatar;
    [SerializeField]
    private Sprite[] avatars;

    Player player;
    private void Start()
    {
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public void Awake()
    {
        backgroundImage = GetComponent<Image>();
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }
    public void ApplyLocalChanges()
    {
        LeftArrowButton.SetActive(true);
        RightArrowButton.SetActive(true);
    }
    public void OnClickLeftArrow() //Similar to our character selection script, but implemented this way for more ditinction and easier for use to differentiate for Photon/Singleplayer
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;

        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRightArrow()
    { 
        if ((int)playerProperties["playerAvatar"] == avatars.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        Debug.Log("Hit");
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if( player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }

    }
}
    

