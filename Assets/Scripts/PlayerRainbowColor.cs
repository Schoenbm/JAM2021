using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRainbowColor : MonoBehaviour
{
	SpriteRenderer sr;
	float H, S, V;
	
	float direction = 1;
	
    // Start is called before the first frame update
    void Start()
	{
		Debug.Log("Hello");
    	sr = GetComponent<SpriteRenderer>();    
    	
		Color.RGBToHSV(sr.color, out H, out S, out V);
    	
		S = 1.0f;
		
		sr.color = Color.HSVToRGB(H, S, V);
    }

    // Update is called once per frame
    void Update()
	{
		H += 0.005f * direction;
		
		if(H >= 1f || H <= 0f)
		{
			direction *= -1;
		}
		
		sr.color = Color.HSVToRGB(H, S, V);
	}
}
