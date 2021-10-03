using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleManager : MonoBehaviour
{
	private List<Rule> rules = new List<Rule>();
	public Rule activeRule; // The active rule applied

	[SerializeField] private float minSeconds = 5.0f;
	[SerializeField] private float maxSeconds = 15.0f;

    private float ruleDuration = 0.0f; // how long does the current rule last
	private float timer = 0.0f; // timer counting the rule has lasted
    
	private GameObject chaosBarFill;

	private void setNewRule()
	{
		gameManager gm = GameObject.Find("GameManager").GetComponent<gameManager>();
		string previousRule = activeRule?.getName();
		
		float chaosTimeModifier =(2 - chaosBarFill.GetComponent<Image>().fillAmount);
		
		ruleDuration = Random.Range(minSeconds, maxSeconds)* chaosTimeModifier;
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

	// Awake is called when the script instance is being loaded.
	protected void Awake()
	{
		chaosBarFill = GameObject.Find("Fill");
	}

    // Start is called before the first frame update
    void Start()
	{
		rules.Add(new Invincible());
		rules.Add(new Nothing());
		rules.Add(new Gravity());
		rules.Add(new InfiniteJumps());
		rules.Add(new CantJump());
		rules.Add(new ConstantShooting());
		rules.Add(new DoubleDamage());
		rules.Add(new AlmostTransparent());
		//BROKEN rules.Add(new AlmostTransparentEnemy());
		rules.Add(new RoussianRoulette());
		rules.Add(new FlipRoom());
		rules.Add(new Shaking());
		rules.Add(new InvertControls()); //assuming just the movement keys are inverted
		rules.Add(new PowerfulRecoil());
		rules.Add(new ChangeSkin());
        //// TODO: Add all rules to list
		
		activeRule = new Nothing();
		activeRule.applyRule();
		ruleDuration = maxSeconds;
	    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
	    //Debug.Log(timer + " : " + ruleDuration);
        if (timer >= ruleDuration)
        {
        	
	        timer = 0.0f;
            activeRule.removeRule(); // remove current rule

	        setNewRule();
	        FindObjectOfType<AudioManager>().Play("New_Rule");
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
