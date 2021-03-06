﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //member variables
    Rigidbody2D rB2D;
    AudioSource audioSource;
    private int count;

    //public variables
    public float runSpeed;
    public float jumpSpeed;
    public int winCount;

    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public AudioClip munchSFX;
    public AudioClip cawSFX;

    // Start is called before the first frame update
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        winTextObject.SetActive(false);

        SetCountText();
    }

    //Updates count text with current data, displays win text
    void SetCountText()
    {
        countText.text = "Fries: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int levelMask = LayerMask.GetMask("Level");

            if (Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.down, .01f, levelMask))
            {
                Jump();
            }
        }
        //check if all fries are collected
        if (count >= winCount)
        {
            winTextObject.SetActive(true);
        }

        //check if player has fallen ; reset
        else if (rB2D.transform.position.y <= -15f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    /// <summary>
    /// Called last every frame ; using for movement
    /// Record input from keys and applies velocity based on input
    /// Sets animation based on whether or not the player is moving
    /// Flips the sprite depending on x velocity
    /// </summary>
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        rB2D.velocity = new Vector2(horizontalInput * runSpeed * Time.deltaTime, rB2D.velocity.y);

        if (rB2D.velocity.x > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else
        if (rB2D.velocity.x < 0f)
        {
            spriteRenderer.flipX = true;
        }

        if (Mathf.Abs(horizontalInput) > 0f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
            animator.SetBool("IsWalking", false);
    }

    //adds y velocity
    void Jump()
    {
        rB2D.velocity = new Vector2(rB2D.velocity.x, jumpSpeed);
    }

    //called when player collides with something
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the collider is the enemy, reset
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    //called when player enters a trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the trigger is a pick up, update count and play sound
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            audioSource.PlayOneShot(munchSFX);

            SetCountText();
        }
        //if the trigger is the enemy's head, kill enemy and jump
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(cawSFX);
            Jump();
        }
    }
}