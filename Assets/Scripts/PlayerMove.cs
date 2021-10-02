using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    int maxJumps = 1;
    int jumpsLeft = 1;
    bool isJumpPressed;

    float coolDownMax = 0.1f;
    float coolDown = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = speed;

        if (jumpsLeft > 0 && Input.GetAxisRaw("Jump") > 0 && !isJumpPressed)
        {
            coolDown = 0.0f;
            rb.velocity = new Vector2(rb.velocity.x, 0); // avoids force building up and avoids jumps being damped
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsLeft--;

            isJumpPressed = true;
        }

        if(Input.GetAxisRaw("Jump") == 0) {
            isJumpPressed = false;
        }

        if (isGrounded())
        {
            if(coolDown >= coolDownMax) {
                jumpsLeft = maxJumps;
            }
        }
        else
        {
            horizontalSpeed *= 0.5f; // you have less movility when in the air
        }

        coolDown += Time.deltaTime;

        float movement = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + movement, transform.position.y, 0);
    }

    // Checks if standing on a platform (use "Level" layer on every jumpable gameobject)
    bool isGrounded()
    {
        float rayOffset = 0.05f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + rayOffset, LayerMask.GetMask("Level"));
        return hit.collider != null;
    }
}
