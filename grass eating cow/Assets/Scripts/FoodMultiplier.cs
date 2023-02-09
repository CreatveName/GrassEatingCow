using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMultiplier : MonoBehaviour
{
    private Collider2D coll;
    private SpriteRenderer sprite;
    private int spawnLife;
    [SerializeField]
    private Food food;

    private void Start() 
    {
        coll = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = food.foodLook;
        spawnLife = food.spawnTime;

        Destroy(gameObject, spawnLife);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();

        if(boolTest)
        {
            boolTest.foodMultiplier = food.value;
        }

    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();
        if(boolTest.isEating)
        {
            Destroy(gameObject, 0f);
        }
    }

}
