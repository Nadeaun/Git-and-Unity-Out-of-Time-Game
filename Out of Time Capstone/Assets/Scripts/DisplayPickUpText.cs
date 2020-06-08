using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPickUpText : MonoBehaviour
{
    public float theDistance;
    public Canvas Main_Canny;
    public GameObject pickUpItemText;
  
    // Update is called once per frame
    void Update()
    {
        theDistance = RaycastItem.DistanceFromTarget;
    }


    void OnMouseOver()
    {
        Debug.Log("MOUSE IS OVER IT");
        if (theDistance <= 5)
        {
            Main_Canny.transform.GetChild(3).gameObject.SetActive(true);
            pickUpItemText.SetActive(true);

        }


    }

    void OnMouseExit()
    {
        pickUpItemText.SetActive(false);
    
    }


}
