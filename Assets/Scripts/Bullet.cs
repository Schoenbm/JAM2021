using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int damage;
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
	

	private void OnTriggerEnter2D(Collider2D collision) 
    {
	    print("Collision with: " + collision.transform.name);
	    if(!collision.transform.CompareTag(this.gameObject.tag)){
		    Animal target = collision.GetComponent<Animal>();
		    if(target)
		    	target.takeDamages(damage);
		    Destroy(this.gameObject);
	    }
    }

}
