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
                // Get the gameobject of the item hit by the ray
                RaycastHit hit_item = getRay();
                GameObject target = hit_item.transform.gameObject;

                Debug.Log(target.name + ": Target name");

                // Compare for different situations

                // Check for holding firepoker and using on figurine
                if (target.name == "BrideFigurine" && held_obj.name == "firepoker")
                {
                    Destroy(held_obj);
                    left_hand.GetComponent<ItemPickUp>().pickItUp(target);
                    target.transform.Rotate(270, 0, 0);
                    target.tag = "Item";
                }

                // Check for holding BrideFigurine and using on cuckoo clock
                if (held_obj.name == "BrideFigurine" && target.name == "CuckooClock")
                {
                    Destroy(held_obj);
                    // Reset the fact you aren't holding anything
                    left_hand.GetComponent<ItemPickUp>().isHolding = false;
                    // Show the figurine in the clock
                    target.transform.GetChild(1).gameObject.SetActive(true);
                    // Finish cuckoo clock puzzle/move onto next puzzle
                }

                // Check for holding pendulum and using on Grandfather clock
                if (held_obj.name == "Pendulum" && target.name == "GrandfatherClock")
                {
                    Destroy(held_obj);
                    // Reset the fact you aren't holding anything
                    left_hand.GetComponent<ItemPickUp>().isHolding = false;
                    // Show the pendulum in the clock
                    target.transform.GetChild(1).gameObject.SetActive(true);
                    // Finish Grandfather clock puzzle/move onto next puzzle
                }

                // Check for holding gear and using on Mantleclock
                if (held_obj.name == "gear" && target.name == "Mantle_Clock")
                {
                    Destroy(held_obj);
                    // Reset the fact you aren't holding anything
                    left_hand.GetComponent<ItemPickUp>().isHolding = false;

                    // Finish Mantle clock puzzle/move onto next puzzle
                }

                // Check for holding wind up key and using on alarm clock
                if (held_obj.name == "WindUpKey" && target.name == "AlarmClock")
                {
                    Destroy(held_obj);
                    // Reset the fact you aren't holding anything
                    left_hand.GetComponent<ItemPickUp>().isHolding = false;
                    // Show wind up key in the alarm clock
                    target.transform.GetChild(1).gameObject.SetActive(true);
                    
                    // Finish Game/load game over scene

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
