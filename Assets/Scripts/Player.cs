using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Animal
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    public float speed = 5.0f;
	public bool isFacingRight = true; // depends on sprite

	public float jumpForce = 0.5f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 5f;
    int maxJumps = 1;
    int jumpsLeft = 1;
    bool isJumpPressed;

	float jumpCoolDownMax = 0.35f;
    float jumpCoolDown = 0.0f;

    float coolDownDashMax = 1f;
    float coolDownDash = 0.0f;
    float dashDistance = 2f;

    public GameObject dashParticlesPrefab;
    GameObject dashParticlesInstance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dashParticlesInstance = Instantiate(dashParticlesPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = speed;
        jumpCoolDown += Time.deltaTime;

	    // Jump
	    
	    if (jumpsLeft > 0 && Input.GetAxisRaw("Jump") > 0 && !isJumpPressed)
	    {
            jumpCoolDown = 0.0f;
            rb.velocity = new Vector2(rb.velocity.x, 0); // avoids force building up and avoids jumps being damped
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsLeft--;

            isJumpPressed = true;
        }

        // Reset can jump
        if (Input.GetAxisRaw("Jump") == 0)
        {
            isJumpPressed = false;
        }

        // if grounded and cooldown done 
        if (isGrounded())
        {
            if (jumpCoolDown >= jumpCoolDownMax)
            {
                jumpsLeft = maxJumps;
            }
        }
        else
        {
	        horizontalSpeed *= 0.9f; // you have less movility when in the air
        }
	    
	    // increase fall speed
	    if(rb.velocity.y < 0)
	    {
	    	rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
	    }
	    else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
	    {
	    	rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
	    }
	    
        
        // Horizontal movement
        float movement = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + movement, transform.position.y, 0);

        // flip
        if ((isFacingRight && Input.GetAxis("Horizontal") < 0) || (!isFacingRight && Input.GetAxis("Horizontal") > 0))
        {
	        isFacingRight = !isFacingRight;
	        //spriteRenderer.flipX = !spriteRenderer.flipX;
	        transform.Rotate(0f, 180f, 0f);
        }

        // Dash
        coolDownDash += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && coolDownDash > coolDownDashMax)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                coolDownDash = 0f;
                dashParticlesInstance.transform.position = transform.position;
                dashParticlesInstance.GetComponent<ParticleSystem>().Play();
                transform.Translate(dashDistance, 0, 0);

            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                coolDownDash = 0f;
                dashParticlesInstance.transform.position = transform.position;
                dashParticlesInstance.GetComponent<ParticleSystem>().Play();
                transform.Translate(dashDistance, 0, 0);
            }

        }
    }

    // Checks if standing on a platform (use "Platform" layer on every jumpable gameobject)
    bool isGrounded()
    {
        float rayOffset = 0.05f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + rayOffset, LayerMask.GetMask("Platform"));
        return hit.collider != null;
    }
    
	override
	public void Die(){
		
	}
}
