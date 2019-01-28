using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeilBox : MonoBehaviour {

    public int heilen = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(heilen == 1)
        {
            
            if ( GameObject.Find("Golem").GetComponent<Bewegung>().l <= 100)
            {
                GameObject.Find("Golem").GetComponent<Bewegung>().l = GameObject.Find("Golem").GetComponent<Bewegung>().l + 5;
            }
            else
            {
                heilen = 0;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="Golem")
        {
            heilen = 1; 
        }
    }
}
