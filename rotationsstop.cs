using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationsstop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Stein_ele2" && GameObject.Find("Käfer").GetComponent<kafer>().rot==0)
        {
            GameObject.Find("Käfer").GetComponent<kafer>().rot = 1;
            GameObject.Find("Käfer").transform.Rotate(0,5,0);
        }
    }

            // Update is called once per frame
            void Update () {
		
	}
}
