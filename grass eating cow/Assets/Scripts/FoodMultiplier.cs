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
    // Renders the sprites for the food to spawn in and be destroyed after a while
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
        if (other.tag == "Crow")
        {
            Destroy(gameObject, 0.5f);
        }
        else
        {
            PlayerAbility boolTest = other.GetComponent<PlayerAbility>();

            if(boolTest)
            {
                boolTest.foodMultiplier = food.value;
            }
        }

    }
    // When the object interacts with the player character and is eaten it destroys it causing it to dissapear.
    private void OnTriggerStay2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();
        if(boolTest.isEating)
        {
            Destroy(gameObject, 0f);
        }
    }

}
