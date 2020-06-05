using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{

    public Transform hand;
    public Transform lighterHand;
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
            Debug.Log("Pew");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3))
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
                    item.transform.GetChild(0).gameObject.SetActive(true);
                    hasLighter = true;
                    lighterActive = true;
                    //GameObject.Find("/Lighter/Particle System").gameObject.SetActive(true);
                }
                if (isHolding == false)
                {
                    if (item.tag == "Item" && item.GetComponent<permission>().allowed)
                    {
                        pickItUp(item);
                        // Make you put away your lighter
                        moveLighter();
                    }

                }
            }
        }
    }

    public void pickItUp(GameObject item)
    {
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.SetPositionAndRotation(hand.transform.position, hand.rotation);
        item.transform.parent = hand.transform;

        // Set to true so that you can't pick up another item
        isHolding = true;
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
        lighterObj.transform.GetChild(0).gameObject.SetActive(false);
    }
}
