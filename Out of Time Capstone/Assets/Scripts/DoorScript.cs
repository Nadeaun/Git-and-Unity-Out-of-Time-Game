using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DoorScript : MonoBehaviour
{
    bool isOpen = false;
    //public bool unlocked = false;
    //public GameObject door;
    Animator animator;
    AudioSource creek;
    private void Start()
    {
        //animator = door.GetComponent<Animator>();
        
        //creek = door.GetComponentInChildren<AudioSource>();
    }


    void OpenDoor()
    {
        isOpen = true;
        DoorControl("Open");
        //creek.Play(0);
    }

    void CloseDoor()
    {
        isOpen = false;
        DoorControl("Close");
        //creek.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isOpen == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.gameObject.tag == "Door" && obj.gameObject.GetComponent<DoorProperties>().unlocked)
                {
                    animator = obj.gameObject.GetComponent<Animator>();
                    OpenDoor();
                    StartCoroutine(waiter());
                    //CloseDoor();
                }

            }
        }
    }

    void DoorControl(string direction)
    {
        animator.SetTrigger(direction);
    }
    
    IEnumerator waiter()
    {
        Debug.Log("waiting");
        yield return new WaitForSecondsRealtime(6f);
        CloseDoor();
    }
    
    
}
