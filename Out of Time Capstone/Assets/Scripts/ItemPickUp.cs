using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======

public class ItemPickUp : MonoBehaviour
{
    
    public Transform hand;
    GameObject held_item;
    public bool isHolding = false;
    public bool lighterActive;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if player is already holding something in their hand (besides lighter)
        if (isHolding == false)
        {
            lighterActive = false;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject item = hit.collider.gameObject;
                    if (item.tag == "Item")
                    {
                        held_item = item;
                        item.GetComponent<Rigidbody>().isKinematic = true;
                        item.transform.SetPositionAndRotation(hand.transform.position, hand.rotation);
                        item.transform.parent = hand.transform;
                        isHolding = true;
                        
                    }
                    
                }
                else
                {
                    Debug.Log("No hit :(");
                }
            }
        }
    }

    void dropItem()
    {
        held_item.GetComponent<Rigidbody>().isKinematic = false;
    }
}
>>>>>>> 4b58b593e0eca18ee16e37edcacad6f1be00e0de
