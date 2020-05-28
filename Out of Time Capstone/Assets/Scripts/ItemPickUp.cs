using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickUp : MonoBehaviour
{

    
    public Transform hand;
    public GameObject item;
    public bool isHolding = false;
    public bool lighterActive;
    //public GameObject mainCamera;
    /*
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    */
    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if player is already holding something in their hand (besides lighter)
        if (isHolding == false)
        {
            lighterActive = false;

            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    var pick_upable_object = hit.transform;
                    if(pick_upable_object.position == item.transform.position)
                    {
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
}
