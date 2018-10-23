using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    private bool facingRight;
    int moveHorizontal;

    // Use this for initialization
    private void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }



    void Flip()
    {
        facingRight = !
        facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }

        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {

                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }

        }
    }


}
