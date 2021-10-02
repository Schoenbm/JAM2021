using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float bulletTravelSpeed = 20f;
	private Rigidbody2D rb;


	void Start(){
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * bulletTravelSpeed;
	}
    // Update is called once per frame
	//void Update()
	//{
	//    this.transform.Translate(new Vector3(bulletTravelSpeed * Time.deltaTime,0));
	//}
	
	private void OnTriggerEnter2D(Collider2D collider) 
    {
        print("Collision with: " + collider.transform.name);
	    if (!collider.transform.CompareTag("Player") && !collider.transform.CompareTag("Bullet"))
            Destroy(this.gameObject);
    }

}
