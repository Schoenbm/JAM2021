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

	private void setNewRule()
	{
		gameManager gm = GameObject.Find("GameManager").GetComponent<gameManager>();
		string previousRule = activeRule?.getName();
		
		ruleDuration = Random.Range(minSeconds, maxSeconds);
		activeRule = rules[Random.Range(0, rules.Count)];
		
		if (activeRule != null && rules.Count > 1)
		{
			while (activeRule.getName() == previousRule)
			{
				activeRule = rules[Random.Range(0, rules.Count)];
			}
		}
		
		gm.setRuleName(this.activeRuleName());
		gm.setDescName(this.activeRuleDescription());

		activeRule.applyRule();
	}

    // Start is called before the first frame update
    void Start()
	{
		//rules.Add(new Gravity());
		//rules.Add(new InfiniteJumps());
		//rules.Add(new CantJump());
		//rules.Add(new ConstantShooting());
		rules.Add(new FlipRoom());
        // TODO: Add all rules to list
		
		setNewRule();
        
	    chaosBarFill = GameObject.Find("Fill");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
	    Debug.Log(ruleDuration);
        if (timer >= ruleDuration)
        {
        	
        	//float chaosTimeModifier = 1 - chaosBarFill.GetComponent<Image>().fillAmount;
        	
	        timer = 0.0f;
            activeRule.removeRule(); // remove current rule

	        setNewRule();
	        Debug.Log(activeRule.getName());
        }
    }
   
	public string activeRuleDescription(){
		return(activeRule.getDescription());
	}
	public string activeRuleName(){
		return(activeRule.getName());
	}
}
