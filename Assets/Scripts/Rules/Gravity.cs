using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : Rule
{
    private GameObject player;
    private GameObject[] enemies;

    private Vector2 baseGravity;

    public Gravity()
    {
        this.ruleName = "Lower Gravity";
        this.description = "The gravity is now reduced";

        baseGravity = Physics2D.gravity;
    }

    public override void applyRule()
    {
        Physics2D.gravity = new Vector2(Physics2D.gravity.x, Physics2D.gravity.y/2);
    }

    public override void removeRule()
    {
        Physics2D.gravity = baseGravity;
    }
}
