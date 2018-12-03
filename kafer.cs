using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kafer : MonoBehaviour {
    //      public  float alpa;
    //public float a;
    //public float b;
    //public float h;
    //public float c;
    //private Vector3 ab;
    public int rot = 1;
	// Use this for initialization
	void Start () {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.name== "Stein_ele2")
    //    {
    //        //strecke zwischen zwei punke bestimmen
    //        ab = GameObject.Find("Stein_ele2").transform.position - GameObject.Find("Käfer").transform.position;
    //        b= Mathf.Sqrt( (ab.x*ab.x) + (ab.y*ab.y) + (ab.z*ab.z));
    //        a =Mathf.Sqrt(a*a+b*b) ;
    //        c = b;

    //        //sin^-1 um winkel zu bekommen (stimmt)
    //        // alpa =(( Mathf.Asin((a / c)) * 180 )/ Mathf.PI);//( a / c));

    //        Debug.Log(alpa);
    //        //print(alpa);

    //        GameObject.Find("Käfer").transform.Rotate(0,alpa,0);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Stein_ele2")
        {
            rot = 0;
        }
    }

    // Update is called once per frame
    void Update () {
        if (rot==0)
        {
            GameObject.Find("Käfer").transform.Rotate(0, 5, 0);
        }
	}
}
