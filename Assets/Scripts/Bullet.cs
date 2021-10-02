using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletTravelSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(bulletTravelSpeed * Time.deltaTime,0));
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        print("Collision with: " + collision.transform.name);
        if (!collision.transform.CompareTag("Player"))
            Destroy(this.gameObject);
    }

}
