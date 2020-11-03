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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        eRB.velocity = new Vector2(enemySpeed * Time.deltaTime, eRB.velocity.y);

        if (walkingL == true)
        {
            eRB.velocity = new Vector2(-enemySpeed * Time.deltaTime, eRB.velocity.y);
        }
        else if (walkingR == true)
        {
            eRB.velocity = new Vector2(enemySpeed * Time.deltaTime, eRB.velocity.y);
        }
    }

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
