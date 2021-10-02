using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    private List<Rule> rules;
    private Rule activeRule; // The active rule applied

    private float minSeconds = 5.0f;
    private float maxSeconds = 15.0f;

    private float ruleDuration = 0.0f; // how long does the current rule last
    private float timer = 0.0f; // timer counting the rule has lasted


    // Start is called before the first frame update
    void Start()
    {
        rules.Add(new Gravity());
        // TODO: Add all rules to list

        ruleDuration = Random.Range(minSeconds, maxSeconds);
        activeRule = rules[Random.Range(0, rules.Count)];

        activeRule.applyRule();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= ruleDuration)
        {
            timer = 0.0f;

            activeRule.removeRule(); // remove current rule

            ruleDuration = Random.Range(minSeconds, maxSeconds); // set new duration
            activeRule = rules[Random.Range(0, rules.Count)]; // choose new active rule

            activeRule.applyRule(); // start rule
        }
    }
}
