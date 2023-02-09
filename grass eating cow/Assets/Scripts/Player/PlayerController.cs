using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    public CharStats charStats;
    private Animator animator;
    public float moveSpeed;
    private Vector2 movement;
    private Rigidbody2D player;
    private string hAxis;
    private string vAxis;
    
    
    void Start() 
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hAxis = "Horizontal" + playerNumber;
        vAxis = "Vertical" + playerNumber;
    }
    private void Awake() 
    {
        moveSpeed = charStats.moveSpeed;
    }
    // Tracks the players X and Y values and updates it constantly.
    void Update()
    {
        movement.x = Input.GetAxisRaw(hAxis);
        movement.y = Input.GetAxisRaw(vAxis);

        /*
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        */
    }
    // With the new location of X and Y it allows the character to move based off of it's base movespeed.   
    private void FixedUpdate() 
    {
        player.AddForce(new Vector2(movement.x, movement.y) * moveSpeed, ForceMode2D.Force);
    }

}
