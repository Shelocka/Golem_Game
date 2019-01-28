using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bewegung : MonoBehaviour {

    private float drehung = 100.0f/60;
    private float geschwindigkeit = 0.1f;
    private float p = 2;
    private int anzahl = 0;
    private int ganzahl = 0;
    public int l = 100;
    public GameObject ziel;
    public int dps = 50;

    public int force = 1000;
    public float fireRate = 20f;
    private float nextTimeToFire = 2f;

    //animations variablen
    public Animator anim;
    public string animName;
    public int aniLaufen = 0;
    public int dAniLaufen = 0;
    public int schlage = 0;
    public int AniSchlag = 0;

    //private static Timer zeit;

    GameObject prefab = Resources.Load("Kugel") as GameObject;
    private bool zielen = false; 
    public GameObject ThirdCamera;
    public GameObject FirstCamera;
    public Texture2D healthbar;
    public Texture2D healthbar_bg;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        //  zeit = new System.Timers.Timer();

        // zeit.Interval = 2000;
        prefab = Resources.Load("Kugel") as GameObject;
    }

   

    void FixedUpdate()
    {
        //if(aniLaufen==0)
        //{
        //    
        //}
        if (Input.GetKeyUp("w") == true)
        {
            anim.Play("Armature|wait0", -1, 0f);
            aniLaufen = 0;
            dAniLaufen = 0;
        }
        if (Input.GetKeyUp("s") == true)
        {
            anim.Play("Armature|wait0", -1, 0f);
            aniLaufen = 0;
            dAniLaufen = 0;
        }
        if (aniLaufen==1&&dAniLaufen==0)
        {
            anim.Play("Armature|laufen", -1, 0f);
            dAniLaufen = 1;
        }
       

            if (Input.GetKey("w") == true)
        {
            aniLaufen = 1;
            //animName = anim.GetType().name;
            bewegung();
        }
        if (Input.GetKey("s") == true)
        {
            aniLaufen = 1;
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
            //aufTeilen();
            verGroessern();
        }
        if (Input.GetKey("r") == true)
        {
            // zusammenFuegen();
            verKleinern();
        }
        if (Input.GetKeyDown("space") == true)
        {
            //l -= 10; 
            //schlagen();
            if(schlage==0&&AniSchlag==0)
            {
                anim.Play("Armature|schlagRechts", -1, 0f);
                schlage++;
                AniSchlag = 1;
                StartCoroutine(zeitVergehen());
                schlagen();
                //Thread.Sleep(500);

                //AniSchlag = 1;
            }
            else
            {
                if(schlage==1 && AniSchlag == 0)
                {
                    anim.Play("Armature|schlagLinks", -1, 0f);
                    schlage++;
                    AniSchlag = 1;
                    StartCoroutine(zeitVergehen());
                    schlagen();
                    // Thread.Sleep(500);
                    // AniSchlag = 1;

                }
                else
                {
                    if (schlage == 2 && AniSchlag == 0)
                    {
                        anim.Play("Armature|schlagOben", -1, 0f);
                        schlage = 0;
                        AniSchlag = 1;
                        StartCoroutine(zeitVergehen());
                        schlagen();
                        // Thread.Sleep(500);

                        // AniSchlag = 1;
                    }
                    
                }
            }

            
            
        }
       
        if(Input.GetKey("left ctrl") == true)
        {
            anim.Play("Armature|FernKampfModus", -1, 0f);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            zielen = !zielen;

            if (zielen == true)
            {
                FirstCamera.SetActive(true);
                ThirdCamera.SetActive(false);
            }
            if (zielen == false)
            {
                ThirdCamera.SetActive(true);
                FirstCamera.SetActive(false);
            }

        }
        
        if (Input.GetMouseButton(0) == true && zielen == true && Time.time >= nextTimeToFire) /**right statt forward*/
        {
            nextTimeToFire = Time.time + 5f / fireRate;
            schiessen();
        }
        // losSchicken();
        //   kommZurueck();
    }

    void schiessen() {

        GameObject newKugel = Instantiate(prefab);
        prefab.transform.eulerAngles = new Vector3(prefab.transform.eulerAngles.x, prefab.transform.eulerAngles.y + 90, prefab.transform.eulerAngles.z);
        prefab.transform.position = transform.position + GameObject.Find("Golem").transform.forward * 2 * -0.5f; //+ new Vector3(-2, .5f, -5); 
        Rigidbody rb_Kugel = newKugel.GetComponent<Rigidbody>();
        // rb_Kugel.transform.Rotate(0,90,0);
        rb_Kugel.AddForce((GameObject.Find("Golem").transform.forward * -1 + new Vector3(0, .1f, 0)) * force); //.3f 2.stelle
        Destroy(newKugel, 2);
    }
    void bewegung()
    {
        
        // aniLaufen = 1;
        //if (Input.GetKey("w") == true)
        //{
           
            var xkoordi =   -geschwindigkeit;
            transform.Translate( 0, 0,xkoordi);

            //if(ganzahl>0)
            //{
            //    for(int f=0;f<ganzahl ;f++)
            //    {
            //        GameObject.Find("mGolem"+f).transform.Translate(xkoordi,0,0);
               
            //    }
               
            //}
        //}
        
    }


    void zurueck()
    {
        if (Input.GetKey("s") == true)
        {
            var xkoordi =   geschwindigkeit;
            transform.Translate( 0, 0,xkoordi);

            //if (ganzahl > 0)
            //{
            //    for (int f = 0; f < ganzahl; f++)
            //    {
            //        GameObject.Find("mGolem" + f).transform.Translate( 0, 0,xkoordi);
            //    }

            //}
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

    //void losSchicken()
    //{
    //    if (Input.GetMouseButton(1)==true)
    //    {
    //        GameObject.Find("mGolem0").transform.Translate(0-geschwindigkeit,0,0);
    //    }
    //}

    //void kommZurueck()
    //{
    //    if (Input.GetMouseButton(0) == true)
    //    {
    //        GameObject.Find("mGolem0").transform.Translate(0 + geschwindigkeit, 0, 0);
    //    }
    //}

    void schlagen()
    {
        Debug.Log(ziel.name);
        if (ziel != null)
        {
            ziel.GetComponent<Zielsuche>().leben = ziel.GetComponent<Zielsuche>().leben - dps;
        }
        // GameObject.Find("Käfer").GetComponent<kafer>().leben = GameObject.Find("Käfer").GetComponent<kafer>().leben - schlag;
        //GameObject.Find(ziel.name).GetComponent<kafer>().leben = GameObject.Find(ziel.name).GetComponent<kafer>().leben - dps;

    }


    IEnumerator zeitVergehen()
    {
        yield return new WaitForSeconds(1);
        AniSchlag = 0;
    }

    void verKleinern()
    {
        if (transform.localScale.x >= 0.05f)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);
        }
    }

    void verGroessern()
    {
        if(transform.localScale.x<=0.25f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.01f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ziel = GameObject.Find(other.name);
    }

    private void OnGUI()
    {
        if (l > 0) {
            GUI.DrawTexture(new Rect(10, 10, 250, 50), healthbar_bg);
            GUI.DrawTexture(new Rect(10, 10, l * 2.5f, 50), healthbar);    
        }
        
    }
}
