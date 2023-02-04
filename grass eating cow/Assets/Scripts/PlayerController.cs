using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    public CharStats charStats;
    public Animator animator;
    public float moveSpeed;
    private Vector2 movement;
    private Rigidbody2D player;
    

    void Start() 
    {
        player = GetComponent<Rigidbody2D>();
    }
    private void Awake() 
    {
        moveSpeed = charStats.moveSpeed;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        /*
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        */
    }

    private void FixedUpdate() 
    {
        player.AddForce(new Vector2(movement.x, movement.y) * moveSpeed, ForceMode2D.Force);
    }

}
