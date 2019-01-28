using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beissen : MonoBehaviour {
    private int biess = 14;
    private int a = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Stein_ele2")
        {
            
            GameObject.Find("Stein_ele2").GetComponent<Bewegung>().l= 100 -biess;

        }


    }
}
