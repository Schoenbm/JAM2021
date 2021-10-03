using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float magnitude;
	Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
	    origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
	    float xOffset = Random.Range(-0.1f,0.1f) * magnitude;
	    float yOffset = Random.Range(-0.1f,0.1f) * magnitude;
	  	
	    transform.localPosition = new Vector3(origin.x+xOffset,origin.y+yOffset,origin.z);
    }
}
