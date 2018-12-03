using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bewegung : MonoBehaviour {

    private float drehung = 100.0f/60;
    private float geschwindigkeit = 0.2f;
    private float p = 2;
    private int anzahl = 0;
    private int ganzahl = 0;

	// Use this for initialization
	void Start () {
		
	}

   

    void FixedUpdate()
    {
        if (Input.GetKey("w") == true)
        {
            bewegung();
        }
        if (Input.GetKey("s") == true)
        {
            zurueck();
        }
        if (Input.GetKey("a") == true)
        {
            links();
        }
        if (Input.GetKey("d") == true)
        {
            rechts();
        }
           


        if (Input.GetKey("q") == true)
        {
            aufTeilen();
        }
        if (Input.GetKey("r") == true)
        {
            zusammenFuegen();
        }

        losSchicken();
        kommZurueck();
    }

    void bewegung()
    {
        

        if (Input.GetKey("w") == true)
        {
            var xkoordi =   -geschwindigkeit;
            transform.Translate(xkoordi, 0, 0);

            if(ganzahl>0)
            {
                for(int f=0;f<ganzahl ;f++)
                {
                    GameObject.Find("mGolem"+f).transform.Translate(xkoordi,0,0);
                }
               
            }
        }
        
    }


    void zurueck()
    {
        if (Input.GetKey("s") == true)
        {
            var xkoordi =   geschwindigkeit;
            transform.Translate(xkoordi, 0, 0);

            if (ganzahl > 0)
            {
                for (int f = 0; f < ganzahl; f++)
                {
                    GameObject.Find("mGolem" + f).transform.Translate(xkoordi, 0, 0);
                }

            }
        }
    }

    void links()
    {
        if(Input.GetKey("a")==true)
                {
                    var zkoordi =   -drehung;
                    transform.Rotate(0, zkoordi, 0);
                

        if (ganzahl > 0)
        {
            for (int f = 0; f < ganzahl; f++)
            {
                GameObject.Find("mGolem" + f).transform.Rotate(0, zkoordi, 0);
            }

        }
        }

    }

    void rechts()
    {
        if (Input.GetKey("d") == true)
                        {
                            var zkoordi =   drehung;
                            transform.Rotate(0, zkoordi, 0);
                        

        if (ganzahl > 0)
        {
            for (int f = 0; f < ganzahl; f++)
            {
                GameObject.Find("mGolem" + f).transform.Rotate(0, zkoordi, 0);
            }

        }
        }
    }

    void aufTeilen()
    {
        if(anzahl<=20)
        {
            //GameObject a = Instantiate(mGolem, mGolem.transform.position = new Vector3(0, 0, 0), mGolem.transform.rotation);
           GameObject a= GameObject.CreatePrimitive(PrimitiveType.Sphere);
            a.transform.position = new Vector3(GameObject.Find("Cube").transform.position.x+p,0.1f, GameObject.Find("Cube").transform.position.z);
            a.name = "mGolem"+anzahl;
           // a.transform.SetParent(GameObject.Find("Cube").transform);
            a.AddComponent<Rigidbody>();
            a.GetComponent<Rigidbody>().useGravity = true;
            a.AddComponent<BoxCollider>();
            a.GetComponent<BoxCollider>().isTrigger = false;
           

            p = p + 2;
            anzahl = anzahl + 1;
            ganzahl = anzahl;
        }
            
        
    }
    void zusammenFuegen()
    {
        if (Input.GetKey("r") == true&& anzahl>=0)
        {
            // Destroy(GameObject.Find("Cube").transform.GetChild(0).gameObject); 
            Destroy(GameObject.Find("mGolem"+anzahl));
            if (anzahl == 0)
            {
               
              // anzahl = anzahl - 1;
             // p = p - 2;
            }
            else
            {
                anzahl = anzahl - 1;
                ganzahl = anzahl;
                p = p - 2;
            }
           
        }
    }

    void losSchicken()
    {
        if (Input.GetMouseButton(1)==true)
        {
            GameObject.Find("mGolem0").transform.Translate(0-geschwindigkeit,0,0);
        }
    }

    void kommZurueck()
    {
        if (Input.GetMouseButton(0) == true)
        {
            GameObject.Find("mGolem0").transform.Translate(0 + geschwindigkeit, 0, 0);
        }
    }




}
