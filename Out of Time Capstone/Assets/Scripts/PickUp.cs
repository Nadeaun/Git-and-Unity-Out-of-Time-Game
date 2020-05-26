using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform hand;
    //public Transform theDestination;
    public GameObject theItem;


    bool holding = false;

    void OnMouseDown()
    {
        if (holding == false)
        {
            //GetComponent<Rigidbody>().useGravity = false;
            //this.transform.position = hand.position;
            //this.transform.parent = hand.transform;
            holding = true;
        }
        if (holding == true)
        {
            //this.transform.parent = null;
            //GetComponent<Rigidbody>().useGravity = true;
            holding = false;
        }


    }

    private void Update()
    {
        if (holding)
        {
            theItem.GetComponent<Rigidbody>().useGravity = false;
            theItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
            theItem.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            theItem.transform.SetParent(hand.transform);
        }
    }
}
/*
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
*/