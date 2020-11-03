using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public variables
    public float enemySpeed;

    //member variables
    Rigidbody2D eRB;

    // Start is called before the first frame update
    void Start()
    {
        eRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        eRB.velocity = new Vector2(enemySpeed * Time.deltaTime, eRB.velocity.y);
    }
}
