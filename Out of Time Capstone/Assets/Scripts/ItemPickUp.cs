using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Transform player;
    public Transform Camera;
    bool inItemRange = false;
    bool carryItem=false;
    private bool collideWithWall=false;


    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.position);
        if(distance <=2.5f)
        {
            inItemRange = true;
        }
        else
        {
            inItemRange = false;
        }
        if(inItemRange && Input.GetKeyUp(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = Camera;
            carryItem = true;
        }

        if(carryItem)
        {
            if(collideWithWall)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                carryItem = false;
                collideWithWall = false;
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            carryItem = false;
        }
        
     
    }



    void OnTriggerEnter()
    {
        if (carryItem)
        {
            collideWithWall = true;
        }
    }






}