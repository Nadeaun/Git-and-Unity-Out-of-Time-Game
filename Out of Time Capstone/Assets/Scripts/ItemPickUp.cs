using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{

    public Transform hand;
    public Transform lighterHand;
    //GameObject held_item; //seemingly redundant variable
    public bool isHolding = false;
    public bool hasLighter = false;
    public bool lighterActive = false;
    public bool hasJournal = false;

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Check if player is already holding something in their hand (besides lighter)
        if (isHolding == false || hasLighter == false || hasJournal == false)
        {
            pickUpItem();
            
        }
    }


    public void pickUpItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject item = hit.collider.gameObject;
                if (item.tag == "JournalBook")
                {
                    hasJournal = true;
                    Destroy(item);
                }
                if (item.tag == "Lighter")
                {
                    item.transform.SetPositionAndRotation(lighterHand.position, lighterHand.rotation);
                    item.transform.parent = lighterHand;
                    hasLighter = true;
                    lighterActive = true;
                }
                if (isHolding == false)
                {
                    if (item.tag == "Item")
                    {
                        //held_item = item; //seemingly redundant variable
                        item.GetComponent<Rigidbody>().isKinematic = true;
                        item.transform.SetPositionAndRotation(hand.transform.position, hand.rotation);
                        item.transform.parent = hand.transform;

                        // Set to true so that you can't pick up another item
                        isHolding = true;
                        // Make you put away your lighter
                        moveLighter();
                    }

                }
            }
        }
    }

    // Puts the lighter out of view of the camera
    public void moveLighter()
    {
        // Create a vector3 to move lighter object up and down
        Vector3 lighterPos = lighterHand.transform.localPosition;
        GameObject lighterObj = lighterHand.transform.GetChild(0).gameObject;
        lighterPos.y = -.5f;
        lighterPos.x = 0f;
        lighterPos.z = 0f;
        lighterObj.transform.localPosition = lighterPos;
        lighterActive = false;
    }
}
