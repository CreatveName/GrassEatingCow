using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MilkManager[] players;
    public GameObject[] milkProducer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SpawnAllPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].instance = Instantiate(milkProducer[players[i].playerNumber], players[i].spawnPoint.position, players[i].spawnPoint.rotation) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].Setup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
