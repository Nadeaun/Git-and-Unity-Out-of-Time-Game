using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
