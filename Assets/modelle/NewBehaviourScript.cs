using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public GameObject ziel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        ziel = GameObject.Find(other.name);
        GameObject.Find("Stein_ele2").GetComponent<Bewegung>().ziel = ziel;
    }
}
