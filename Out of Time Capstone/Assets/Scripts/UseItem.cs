using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{

    //GameObject left_hand;
    //GameObject held_obj;
    
    private void Start()
    {
        Debug.Log("Start the start of the UseItem start");
        
        
        Debug.Log("UseItem Start fxn pass");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject left_hand = GameObject.Find("/First Person Player/Main Camera/hand").gameObject;
        bool hasItem = left_hand.GetComponent<ItemPickUp>().isHolding;
        
        // Check if you are holding an item
        if (hasItem)
        {
            GameObject held_obj = left_hand.transform.GetChild(0).gameObject;
            // Get a ray/hit
            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit hit_item = getRay();

                GameObject item = hit_item.transform.gameObject;
                if (item.name == "BrideFigurine" && held_obj.name == "firepoker")
                {
                    Destroy(held_obj);
                    left_hand.GetComponent<ItemPickUp>().pickItUp(item);
                    item.transform.Rotate(270, 0, 0);
                }


            }
        }
    }

    RaycastHit getRay()
    {
        Debug.Log("User PEW");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 4);
        Debug.Log(hit.transform.gameObject.name);
        return hit;
    }
}
