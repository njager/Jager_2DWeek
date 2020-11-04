using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public variables
    public float enemySpeed;
    public SpriteRenderer spriteRenderer;

    //member variables
    Rigidbody2D eRB;
    bool walkingR;
    bool walkingL;

    // Start is called before the first frame update
    void Start()
    {
        eRB = GetComponent<Rigidbody2D>();

        walkingL = false;
        walkingR = true;
    }

    //called last every frame
    private void FixedUpdate()
    {
        //sets a positive x velocity ofr enemy
        eRB.velocity = new Vector2(enemySpeed * Time.deltaTime, eRB.velocity.y);

        //if enemy has hit the left edge, walk right
        if (walkingL == true)
        {
            eRB.velocity = new Vector2(-enemySpeed * Time.deltaTime, eRB.velocity.y);
        }
        ///if enemy has hit right edge, walk left
        else if (walkingR == true)
        {
            eRB.velocity = new Vector2(enemySpeed * Time.deltaTime, eRB.velocity.y);
        }
    }

    //called when the enemy enters a trigger, that being the edge of the map
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sign"))
        {
            if (walkingR == true)
            {
                walkingL = true;
                walkingR = false;
                spriteRenderer.flipX = true;
            }
            else
            {
                walkingL = false;
                walkingR = true;
                spriteRenderer.flipX = false;
            }
        }
    }
}
