using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlineRanSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] foodtoSpawn;
    [SerializeField]
    private Transform MinXMaxY;
    [SerializeField]
    private Transform MinYMaxX;
    [SerializeField]
    private float timeBetweenSpawn;
    private float maxX;
    private float minX;
    private float maxY;
    private float minY;
    private float SpawnTime;

    private void Start() 
    {
        minY = MinYMaxX.transform.position.y;
        maxX = MinYMaxX.transform.position.x;
        minX = MinXMaxY.transform.position.x;
        maxY = MinXMaxY.transform.position.y;
        SpawnTime = 3f; //used 3 here because its start delay from game manager, will code in later, but lazy rn
    }

    void Update()
    {
        SpawnTime -= Time.deltaTime;

        if(SpawnTime <= 0)
        {
            spawn();
            SpawnTime = timeBetweenSpawn;
        }
    }
    void spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        int spawnNum = Random.Range(0, foodtoSpawn.Length); 
        Vector2 pos = new Vector2(x, y);
        PhotonNetwork.Instantiate(foodtoSpawn[spawnNum].name, pos, transform.rotation);//might add probability chances later to lower chance of better fruit
    }
}

    