using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hitPoints = 3;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.CompareTag("Bullet")) 
        {
            hitPoints -= 1;
            if (hitPoints <= 0)
                Destroy(this.gameObject);
        }
    }
}
