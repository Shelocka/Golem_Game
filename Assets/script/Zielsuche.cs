using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zielsuche : MonoBehaviour
{

    public int leben = 50;
    public int angrief = 5;
    public int totp = 0;

    //laufen
    public float abst;
    public int laufen = 0;
    private float o;
    private float c;
    private Vector3 ab;
    private Vector3 ac;
    public Animator anim;
    //für trehung
    public float ry = 0;
    public float yzwei = 0;
    public float a = 0;
    public float b = 0;
    // public float bzwei = 0;
    public float zielR = 0;
    public int darf = 0;
    public int darfAg = 1;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        a = transform.localEulerAngles.y;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name== "CubeW")
    //    {
    //        a = transform.localEulerAngles.y;
    //        b = GameObject.Find("CubeW").transform.localEulerAngles.y;
    //        ry = -b - a;
    //        ry = (ry* -1-180) ;
    //       // bzwei = (transform.localEulerAngles.y );
    //        yzwei = (ry*-1+180 );
    //        //transform.eulerAngles = new Vector3(0,y,0);
    //        darf = 1;
    //    }
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        drehung();
        nLaufen();

        if (darf == 1 && totp != 1)
        {
            if (GameObject.Find("Golem").transform.position.x <= transform.position.x)
            {
                if (ry >= transform.localEulerAngles.y)
                {

                    transform.Rotate(0, 0.4f, 0);
                    // anim.Play("Armature|ArmatureAction", -1, 0f);

                }
                else
                {
                    darf = 0;
                    laufen = 1;
                }
            }
            else
            {
                if (transform.localEulerAngles.y >= yzwei || transform.localEulerAngles.y == 0)
                {
                    transform.Rotate(0, -0.4f, 0);
                }
                else
                {
                    darf = 0;
                    laufen = 1;
                }

            }




        }

        if (laufen == 1 && abstand() > 1 && totp != 1)
        {

            //x=z y=x z=y
            transform.Translate(0, 0, -0.1f);

        }




        if (leben == 0)
        {
            transform.localScale = new Vector3(0.25f, 0.1f, 0.25f);
            if (totp == 0)
            {
                transform.Translate(0, 0, -0.16f);
                totp = 1;

                StartCoroutine(zeitTot());

            }

        }
        //angreifen
        if (darfAg == 1 && totp != 1)
        {
            angreifen();

        }
    }


    float abstand()
    {
        //strecke zwischen zwei punke bestimmen
        ab = GameObject.Find("Golem").transform.position - transform.position;
        o = Mathf.Sqrt((ab.x * ab.x) + (ab.y * ab.y) + (ab.z * ab.z));
        //a =Mathf.Sqrt(a*a+b*b) ;
        c = o;
        return c;
    }

    void drehung()
    {
        abst = abstand();
        if (abst <= 3)
        {

            b = GameObject.Find("Golem").transform.localEulerAngles.y;
            ry = -b - a;
            ry = (ry * -1 - 180);

            yzwei = (ry * -1) + 180;

            // ab = GameObject.Find("Golem").transform.position-this.transform.position;
            // ac = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-5) -this.transform.position;

            //ry = Mathf.Asin(((ab.x  + ab.y  + ab.z)  * (ac.x  + ac.y  + ac.z) ) /( Mathf.Sqrt(ab.x*ab.x+ab.y*ab.y+ab.z*ab.z)* Mathf.Sqrt(ac.x * ac.x + ac.y * ac.y + ac.z * ac.z)))*180/Mathf.PI;
            // Debug.Log(ry);
            darf = 1;
        }

    }

    void nLaufen()
    {
        if (abst >= 6)
        {
            laufen = 0;
        }
    }

    IEnumerator zeitVergehen()
    {

        yield return new WaitForSeconds(1);
        darfAg = 1;


    }

    IEnumerator zeitTot()
    {

        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);


    }


    void angreifen()
    {
        if (abst < 1 && darfAg == 1)
        {
            GameObject.Find("Golem").GetComponent<Bewegung>().l = GameObject.Find("Golem").GetComponent<Bewegung>().l - angrief;
            darfAg = 0;
            StartCoroutine(zeitVergehen());
        }

    }
}