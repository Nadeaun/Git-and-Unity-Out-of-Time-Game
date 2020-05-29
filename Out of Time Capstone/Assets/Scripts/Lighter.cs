using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    bool e_pressed = false;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && ! e_pressed)
        {
            // GETS THE ITEM AND DROPS IT

            // Gets the GameObject for the "hand" which holds the game items
            GameObject left_hand = GameObject.Find("/First Person Player/Main Camera/hand");
            // Ensures there is an item to be dropped if not do nothing
            if (left_hand.transform.childCount > 0)
            {
                // Ensures that you can only press "e" once and not flood with "e" input constantly trying to pick something up
                e_pressed = true;
                Debug.Log("E is pressed");
                // Gets the GameObject of the item in the "hand" that holds the game item
                GameObject handydandyitem = left_hand.transform.GetChild(0).gameObject;
                // Enables physics on the item
                handydandyitem.GetComponent<Rigidbody>().isKinematic = false;
                // Unparents the item from the "hand"
                handydandyitem.transform.parent = null;
                // Changes the bool in the "hand" script saying it is able to pick up another item
                left_hand.GetComponent<ItemPickUp>().isHolding = false;
            }

            if (left_hand.GetComponent<ItemPickUp>().hasLighter == true)
            {
                if (left_hand.GetComponent<ItemPickUp>().lighterActive == true)
                {
                    left_hand.GetComponent<ItemPickUp>().moveLighter();
                }
                else
                {
                    // GETS THE LIGHTER AND PUTS IT BACK IN VIEW

                    Vector3 lighterPos = GameObject.Find("/First Person Player/Main Camera/lighter_hand").transform.localPosition;
                    lighterPos.y = 0f;
                    lighterPos.x = 0f;
                    lighterPos.z = 0f;
                    GameObject lighterObj = transform.GetChild(0).gameObject;
                    lighterObj.transform.localPosition = lighterPos;
                    left_hand.GetComponent<ItemPickUp>().lighterActive = true;
                }
                
            }

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("E is UNpressed");
            e_pressed = false;
        }
    }
}
