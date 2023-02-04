using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MilkManager[] players;
    public GameObject[] milkProducer;

    //MAKE SINGLETON AND TEST TO SEE IF IT WORKS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SpawnAllPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
            players[i].instance = Instantiate(milkProducer[selectedCharacter], players[i].spawnPoint.position, players[i].spawnPoint.rotation) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].Setup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
