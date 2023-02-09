using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMultiplier : MonoBehaviour
{
    private Collider2D coll;
    [SerializeField]
    private Food food;

    private void Start() 
    {
        coll = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerAbility boolTest = other.GetComponent<PlayerAbility>();

        if(boolTest)
        {
            boolTest.foodMultiplier = food.value;

            if(boolTest.isEating)
            {
                Destroy(gameObject, 0f);
            }
        }

    }
}
