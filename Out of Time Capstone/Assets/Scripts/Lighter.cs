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
            GameObject left_hand = GameObject.Find("/First Person Player/Main Camera/hand");
            e_pressed = true;
            Debug.Log("E is pressed");
            GameObject handydandyitem = left_hand.transform.GetChild(0).gameObject;
            handydandyitem.GetComponent<Rigidbody>().isKinematic = false;
            handydandyitem.transform.parent = null;
            left_hand.GetComponent<ItemPickUp>().isHolding = false;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("E is UNpressed");
            e_pressed = false;
        }
    }
}
