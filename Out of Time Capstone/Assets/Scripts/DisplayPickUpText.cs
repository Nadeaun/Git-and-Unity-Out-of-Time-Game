using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPickUpText : MonoBehaviour
{
    public float theDistance;

    public GameObject pickUpItemText;
  
    // Update is called once per frame
    void Update()
    {
        theDistance = RaycastItem.DistanceFromTarget;
    }


    void OnMouseOver()
    {

        if (theDistance <= 5)
        {
            pickUpItemText.SetActive(true);

        }


    }

    void OnMouseExit()
    {
        pickUpItemText.SetActive(false);
    
    }


}
