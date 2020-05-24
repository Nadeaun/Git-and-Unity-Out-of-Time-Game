using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   
   
    public Transform theDestination;
    public GameObject theItem;


    // Update is called once per frame
    void FixedUpdate()
    {



        if (Input.GetKeyDown(KeyCode.E))
        {

            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<Rigidbody>().detectCollisions = true;

           
            this.transform.position = theDestination.position;
            this.transform.parent = GameObject.Find("Destination").transform;

            //GetKeyDown
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().detectCollisions = true;
            GetComponent<BoxCollider>().enabled = true;

        }

        //GetKeyUp



    }

    
        
    
        
}
