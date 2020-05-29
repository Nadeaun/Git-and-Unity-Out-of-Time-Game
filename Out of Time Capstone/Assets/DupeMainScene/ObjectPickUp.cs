using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    public bool canHold = true;
    Vector3 objectPosition;
    public GameObject theItem;
    public GameObject Parent;
    public bool isHolding = false;
    float distance;

    void Update()
    {
        distance = Vector3.Distance(theItem.transform.position, Parent.transform.position);
        if(distance >=1f)
        {
            isHolding = false;
        }
            
        if(isHolding==true)
        {
            theItem.GetComponent<Rigidbody>().velocity = Vector3.zero;
            theItem.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            theItem.transform.SetParent(Parent.transform);
            
        }
        else
        {
            objectPosition = theItem.transform.position;
            theItem.transform.SetParent(null);
            theItem.GetComponent<Rigidbody>().useGravity = true;
            theItem.transform.position = objectPosition;
        }
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(distance<=1f)
            {
                isHolding = true;
                theItem.GetComponent<Rigidbody>().useGravity = false;

                theItem.GetComponent<Rigidbody>().detectCollisions = true;
            }
           

        }

        if(Input.GetKeyUp(KeyCode.G))
        {
            isHolding = false;
        }


    }
}