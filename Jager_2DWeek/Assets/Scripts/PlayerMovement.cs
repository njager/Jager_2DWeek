using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    //member variables
    Rigidbody2D rB2D;
    private int count;

    //public variables
    public float runSpeed;
    public float jumpSpeed;
    public TextMeshProUGUI countText;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        SetCountText();
    }

    //Updates count text with current data, displays win text
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    /*
    void UpdateCountText()
    {
        count += 1;
        SetCountText();
    }
    */

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
    }

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

    void Jump()
    {
        rB2D.velocity = new Vector2(rB2D.velocity.x, jumpSpeed);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            
            SetCountText();
        }
    }
}
