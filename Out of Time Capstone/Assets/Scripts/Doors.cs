using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator animator;
    bool doorOpen;
    public bool unlocked;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
        unlocked = false;
       
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Player" && unlocked)
        {
            doorOpen = true;
            DoorControl("Open");
            GetComponentInChildren<AudioSource>().Play(0);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(doorOpen)
        {
            doorOpen = false;
            DoorControl("Close");
            GetComponentInChildren<AudioSource>().Play(0);
        }
    }

    void DoorControl(string direction)
    {
        animator.SetTrigger(direction);
            
             
        


    }
}
