using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    public Transform inHand;

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = inHand.transform.position;
            this.transform.parent = GameObject.Find("First Person Player").transform;
            this.transform.parent = GameObject.Find("Main Camera").transform;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }



    }



   
}

