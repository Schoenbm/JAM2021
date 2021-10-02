using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public int hitPoints = 3;
    public float travelSpeed = 2.0f;
    public string spawnerName;

    private int direction = 1;
    private void Update()
    {
        this.transform.Translate(new Vector2(travelSpeed * direction * Time.deltaTime, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        switch (collision.transform.tag) 
        {
            case "Bullet":
                hitPoints -= 1;
                if (hitPoints <= 0)
                    Destroy(this.gameObject);
                break;

            case "Enemy": //TODO
            case "Player": //TODO
            case "Wall":
                direction *= -1;
                break;
            
        }
    }

    private void OnDestroy() 
    {
        GameObject go;

        //Allot a slot for another enemy to spawn
        go = GameObject.Find(spawnerName);
        if (go != null)
            go.GetComponent<SpawnEnemies>().spawnsRemaining += 1;
    }

}
