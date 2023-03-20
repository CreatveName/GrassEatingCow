using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    public CharStats charStats;
    public float moveSpeed;
    private Vector2 movement;
    [SerializeField]
    private Rigidbody2D player;
    private string hAxis;
    private string vAxis;
    PhotonView view;
    [SerializeField]
    private AudioSource ad;
    [SerializeField]
    private float soundLimit;
    private float soundTimer;



    void Start()
    {
        hAxis = "Horizontal" + playerNumber;
        vAxis = "Vertical" + playerNumber;
        view = GetComponent<PhotonView>();
        soundTimer = soundLimit;
    }
    private void Awake()
    {
        moveSpeed = charStats.moveSpeed;
        ad.clip = charStats.charSound;
    }
    // Tracks the players X and Y values and updates it constantly.
    void Update()
    {
        movement.x = Input.GetAxisRaw(hAxis);
        movement.y = Input.GetAxisRaw(vAxis);
    }
    // With the new location of X and Y it allows the character to move based off of it's base movespeed.   
    private void FixedUpdate()
    {
        player.AddForce(new Vector2(movement.x, movement.y) * moveSpeed, ForceMode2D.Force);

        soundTimer -= Time.fixedDeltaTime;

        if(soundTimer <= 0)
        {
            ad.Play();
            float soundCD = Random.Range(10f, 10f + soundLimit);
            soundTimer = soundCD;
        }
    }

    public void Stall()
    {
        StartCoroutine(Hurt());
    }

    IEnumerator Hurt()
    {
        moveSpeed = 0f;
        yield return new WaitForSeconds(3f);
        moveSpeed = charStats.moveSpeed;
    }


}
