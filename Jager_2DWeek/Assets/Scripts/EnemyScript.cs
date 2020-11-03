﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public variables
    public float enemySpeed;

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
            eRB.velocity = -eRB.velocity;
            print("Is walking left");
        }
        else if (walkingR == true)
        {
            eRB.velocity = -eRB.velocity;
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
                print("Hit left wall");
            }
            else
            {
                walkingL = false;
                walkingR = true;
            }
        }
    }
}
