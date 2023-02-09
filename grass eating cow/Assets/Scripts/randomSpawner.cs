using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawner : MonoBehaviour
{
    public GameObject[] foodtoSpawn;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float SpawnTime;



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
        float x = Random.Range(minX, maxY);
        float y = Random.Range(maxX, minY);
        int spawnNum = Random.Range(0, foodtoSpawn.Length); 
        Vector2 pos = new Vector2(x, y);
        Instantiate(foodtoSpawn[spawnNum], pos, transform.rotation);//might add probability chances later to lower chance of better fruit
    }
}

    