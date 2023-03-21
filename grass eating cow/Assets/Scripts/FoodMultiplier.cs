using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMultiplier : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    private int spawnLife;
    [SerializeField]
    private Food food;
    // Renders the sprites for the food to spawn in and be destroyed after a while
    private void Start() 
    {
        sprite.sprite = food.foodLook;
        spawnLife = food.spawnTime;

        Destroy(gameObject, spawnLife);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Crow")
        {
            Destroy(gameObject, 0f);
        }
        else
        {
            PlayerAbility boolTest = other.GetComponent<PlayerAbility>();
            OnlinePAbility bools = other.GetComponent<OnlinePAbility>();

            if(boolTest)
            {
                boolTest.foodMultiplier = food.value;
            }

            if(bools)
            {
                bools.foodMultiplier = food.value;
            }
        }

    }
    // When the object interacts with the player character and is eaten it destroys it causing it to dissapear.
    private void OnTriggerStay2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();
        OnlinePAbility bools = other.GetComponent<OnlinePAbility>();

        if(boolTest && boolTest.isEating)
        {
            Destroy(gameObject, 0f);
        }

        if(bools && bools.isEating)
        {
            Destroy(gameObject, 0f);
        }
    }

}
