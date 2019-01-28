using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kafer : MonoBehaviour {
    //      public  float alpa;
    public float a;
    public float b;
    //public float h;
   public float c;
    private float z;
    private Vector3 ab;
    public int rot = 1;
    public int laufen = 0;
    private string name;
    public int leben= 100;
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
            laufen = 1;
            Debug.Log(abstand());
            
            
            
        } 

        
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (rot==0)
        {
            transform.Rotate(0, 5, 0);
        }

        //if(laufen==1)
        //{
        //    bewegen();
        //    if(abstand()>=0.5f)
        //    {
        //        laufen = 0;
        //    }
        //}
        z = abstand();
        if(z>=1&&laufen==1&&rot==1)
        {
            bewegen();
            z = abstand();
        }
        
       
	}


    float abstand()
    {
        //strecke zwischen zwei punke bestimmen
              ab = GameObject.Find("Stein_ele2").transform.position - GameObject.Find("Käfer").transform.position;
               b= Mathf.Sqrt( (ab.x*ab.x) + (ab.y*ab.y) + (ab.z*ab.z));
               //a =Mathf.Sqrt(a*a+b*b) ;
               c = b;
        return c;
    }

    void bewegen ()
    {
        transform.Translate(0,0,-0.05f);
    }
}
