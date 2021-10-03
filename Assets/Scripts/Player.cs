using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Animal
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
	
	[Range(0,0.5f)] public float smoothing = 0.05f;
    public float speed = 5.0f;
	public bool isFacingRight = true; // depends on sprite

	public float jumpForce = 0.5f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 5f;
	int maxJumps = 1;
    int jumpsLeft = 1;
	bool isJumpPressed;
	public int Inverted {get; set;}

	float jumpCoolDownMax = 0.35f;
    float jumpCoolDown = 0.0f;

    float coolDownDashMax = 1f;
    float coolDownDash = 0.0f;
	public float dashForce = 2f;
	public float dashInvulnerabilityFrame = 0.5f;
	private bool canDash = true;

    public GameObject dashParticlesPrefab;
	GameObject dashParticlesInstance;
    

    public int getMaxHealth() {return totalHealthPoints;}
	public int getCurrentHealth(){return currentHealthPoints;}
	
    // Start is called before the first frame update
    void Start()
	{
		Inverted = 1;
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dashParticlesInstance = Instantiate(dashParticlesPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        setGm(FindObjectOfType<gameManager>());
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
        if (canMove)
        {
	        float movement = Input.GetAxis("Horizontal") * horizontalSpeed;
	        Vector3 targetVelocity = new Vector2(movement * Inverted, rb.velocity.y);
            // And then smoothing it out and applying it to the character
	        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref vectorZero , smoothing);
        }



        // flip
        if ((isFacingRight && Input.GetAxis("Horizontal") < 0) || (!isFacingRight && Input.GetAxis("Horizontal") > 0))
        {
	        isFacingRight = !isFacingRight;
	        spriteRenderer.flipX = !spriteRenderer.flipX;
	        //transform.Rotate(0f, 180f, 0f);
        }

        // Dash
        coolDownDash += Time.deltaTime;

	    if (Input.GetKeyDown(KeyCode.LeftShift) && coolDownDash > coolDownDashMax && canDash)
        {
        	coolDownDash = 0f;
            dashParticlesInstance.transform.position = transform.position;
            dashParticlesInstance.GetComponent<ParticleSystem>().Play();
            this.StartCoroutine(CantMove(dashInvulnerabilityFrame));
	        this.StartCoroutine(Invulnerable(dashInvulnerabilityFrame));
	        if(isFacingRight)
		        this.rb.AddForce(dashForce * transform.right);
	        else
		        this.rb.AddForce(-dashForce * transform.right);
	        	
	        	

        }
    }

    // Checks if standing on a platform (use "Platform" layer on every jumpable gameobject)
    bool isGrounded()
    {
	    float rayOffset = 0.6f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + rayOffset, LayerMask.GetMask("Platform"));
        return hit.collider != null;
    }
    
	public void setMaxJumps(int jumps){
		maxJumps = jumps;
	}
    
	public void setDash(bool b){
		canDash = b;
	}
    
	override public void Die(){
		gm.GameOver();
	}
}
