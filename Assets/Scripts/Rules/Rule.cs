using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule
{
    protected string ruleName;
    protected string description;

    public abstract void applyRule();

    public abstract void removeRule();
}
