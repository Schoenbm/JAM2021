using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleManager : MonoBehaviour
{
	private List<Rule> rules = new List<Rule>();
    private Rule activeRule; // The active rule applied

    private float minSeconds = 5.0f;
    private float maxSeconds = 15.0f;

    private float ruleDuration = 0.0f; // how long does the current rule last
	private float timer = 0.0f; // timer counting the rule has lasted
    
	private GameObject chaosBarFill;

    // Start is called before the first frame update
    void Start()
	{
		rules.Add(new Gravity());
		Debug.Log("hola");
	    rules.Add(new InfiniteJumps());
        // TODO: Add all rules to list
		
        ruleDuration = Random.Range(minSeconds, maxSeconds);
        activeRule = rules[Random.Range(0, rules.Count-1)];

	    activeRule.applyRule();
        
	    chaosBarFill = GameObject.Find("Fill");
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= ruleDuration)
        {
        	
        	float chaosTimeModifier = 1 - chaosBarFill.GetComponent<Image>().fillAmount;
        	
            timer = 0.0f;
	        Debug.Log(activeRule.getName());
            activeRule.removeRule(); // remove current rule

	        ruleDuration = Random.Range(minSeconds, maxSeconds) * chaosTimeModifier; // set new duration
            activeRule = rules[Random.Range(0, rules.Count-1)]; // choose new active rule

            activeRule.applyRule(); // start rule
        }
    }
   
	public string activeRuleDescription(){
		return(activeRule.getDescription());
	}
	public string activeRuleName(){
		return(activeRule.getName());
	}
}
