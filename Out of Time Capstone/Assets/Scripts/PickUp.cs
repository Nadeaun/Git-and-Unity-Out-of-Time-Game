using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform theDestination;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = false;
            this.transform.position = theDestination.position;
            this.transform.parent = GameObject.Find("Destination").transform;


        }

        if(Input.GetKeyUp(KeyCode.G))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;

        }


    }
}
