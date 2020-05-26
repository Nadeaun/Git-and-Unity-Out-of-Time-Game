using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    

    public Transform hand;
    public GameObject item;
    public bool isHolding = false;
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
        if (isHolding == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("CLICK!");
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log("hit!");
                    var pick_upable_object = hit.transform;
                    Debug.Log(item.transform.position + ": Object transform position");
                    Debug.Log(pick_upable_object + ": Hit transform position");
                    Debug.Log(hand.transform.position + ": Hand transform position");
                    if(pick_upable_object.position == item.transform.position)
                    {
                        Debug.Log("move to hand");
                        //isHolding = true;
                        item.GetComponent<Rigidbody>().useGravity = false;
                        Debug.Log("Pass");
                        item.transform.SetPositionAndRotation(hand.transform.position, hand.rotation);
                        Debug.Log("Its a hit!");
                        item.transform.parent = hand.transform;
                        
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
