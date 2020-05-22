using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   float throwForce=10;
    Vector3 objPosition;
    float distance;
    public GameObject item;
    public bool canHold = true;
    public GameObject tempParent;
    public bool isHolding = false;
   
    // Update is called once per frame
    void Update()
    {
        if(isHolding==true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if(Input.GetMouseButtonDown(1))
            {

            }
            else
            {
                objPosition = item.transform.position;
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.transform.position = objPosition;
            }
            
        }
    }

   void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.E))
        isHolding = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
    }

    void OnMouseUp()
    {
        isHolding=false;

    }

}
