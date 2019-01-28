using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angreifen : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.name == "CubeW")
        {

            GameObject.Find("CubeW").GetComponent<Bewegung>().l = 100 - GameObject.Find("slime_rigged_animated4").GetComponent <Zielsuche>().angrief;

        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
