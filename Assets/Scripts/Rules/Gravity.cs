using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : Rule
{
    private GameObject player;
    private GameObject[] enemies;

    private float playerBaseGravity;
    private float enemyBaseGravity;

    public Gravity()
    {
        this.ruleName = "Lower Gravity";
        this.description = "The gravity is now reduced";

        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        playerBaseGravity = player.GetComponent<Rigidbody2D>().gravityScale;
        enemyBaseGravity = enemies[0].GetComponent<Rigidbody2D>().gravityScale;
    }

    public override void applyRule()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 1;

        foreach (GameObject e in enemies)
        {
            e.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    public override void removeRule()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = playerBaseGravity;

        foreach (GameObject e in enemies)
        {
            e.GetComponent<Rigidbody2D>().gravityScale = enemyBaseGravity;
        }
    }
}
