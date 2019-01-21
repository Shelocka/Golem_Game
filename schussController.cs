using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schussController : MonoBehaviour
{
    GameObject prefab = Resources.Load("Kugel") as GameObject;
    private bool zielen = false; //new
    public GameObject ThirdCamera;
    public GameObject FirstCamera;


    void Start()
    {
        prefab = Resources.Load("Kugel") as GameObject;
    }


    void FixedUpdate()
    {
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

        if (Input.GetMouseButton(0) == true && zielen == true)
        {
            GameObject newKugel = Instantiate(prefab);
            prefab.transform.position = transform.position + GameObject.Find("Stein_ele2").transform.forward * 2 + new Vector3(0, .5f, 2); // höhe
            Rigidbody rb_Kugel = newKugel.GetComponent<Rigidbody>();
            rb_Kugel.AddForce((GameObject.Find("Stein_ele2").transform.forward + new Vector3(0, .3f, 0)) * 1000);
        }
    }
}
