using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public bool e_pressed = false;
    
    

    // Update is called once per frame
    void Update()
    {
        GameObject left_hand = GameObject.Find("/First Person Player/Main Camera/hand");

        if (Input.GetKeyDown("e") && ! e_pressed)
        {
            // GETS THE ITEM AND DROPS IT
            //GameObject left_hand = GameObject.Find("/First Person Player/Main Camera/hand");

            // Ensures there is an item to be dropped if not do nothing
            if (left_hand.transform.childCount > 0)
            {
                // Ensures that you can only press "e" once and not flood with "e" input constantly trying to pick something up
                e_pressed = true;
                //Debug.Log(e_pressed + "E is pressed");
                //Debug.Log("E is pressed");
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
                // Gets the Lighter game object
                GameObject lighterObj = transform.GetChild(0).gameObject;

                if (left_hand.GetComponent<ItemPickUp>().lighterActive == true)
                {
                    left_hand.GetComponent<ItemPickUp>().moveLighter();
                    lighterObj.transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    // GETS THE LIGHTER AND PUTS IT BACK IN VIEW

                    Vector3 lighterPos = GameObject.Find("/First Person Player/Main Camera/lighter_hand").transform.localPosition;
                    lighterPos.y = 0f;
                    lighterPos.x = 0f;
                    lighterPos.z = 0f;
                    
                    lighterObj.transform.localPosition = lighterPos;
                    left_hand.GetComponent<ItemPickUp>().lighterActive = true;
                    lighterObj.transform.GetChild(0).gameObject.SetActive(true);
                }
                
            }
            e_pressed = false;
        }
        //GameObject left_hand = GameObject.Find("/First Person Player/Main Camera/hand");
        // If lighter is active and player is left clicking, light the candle
        if (left_hand.GetComponent<ItemPickUp>().lighterActive == true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Start lighting the CANLDELjlkf");
            lightCandle();
            Debug.Log("ENDING THE LIGHTING OF TH ECANLDE SEQUESFN");
            
        }

        //if (Input.GetKeyUp("e"))
        //{
        //    Debug.Log("E is UNpressed");
        //}
    }
    void lightCandle()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2))
        {
            GameObject candle = hit.collider.gameObject;
            if (candle.tag == "Candle")
            {
                candle.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
