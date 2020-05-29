using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{


    public Transform theDestination;
    //  public GameObject theItem;
    public bool canHold;
    // no objects are  currently  being held so can hold object
    public bool cannotHold;// cant hold any other objects when one object is already being held

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pendulum")
        {
            canHold = true;
        }
        else if (col.gameObject.tag == "Wind Up Key" && canHold)
        {
            cannotHold = true;

        }



    }
        // Update is called once per frame
        void FixedUpdate()
        {


            //this is a function to PICK UP OBJECT when E KEY is pressed (gravity is false)
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

            // this is a function when OBJECT IS ALREADY BEING PICKED UP you press E KEY to drop ( gravity is set back to true)

            else if (Input.GetKeyUp(KeyCode.E))
            {

                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().detectCollisions = true;
                GetComponent<BoxCollider>().enabled = true;

            }

            //GetKeyUp



        }





    
}
