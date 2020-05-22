using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUItoggle: MonoBehaviour
{
    public GameObject Journal;
    public GameObject page1;
    public GameObject page2;
    
    public void JournalToggle()
    {
        if (Journal != null)
        {
            bool isActive = Journal.activeSelf;

            Journal.SetActive(!isActive);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            JournalToggle();
        }
        if (Journal.activeSelf)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (page1.activeSelf)
                {
                    page1.SetActive(false);
                    page2.SetActive(true);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (page2.activeSelf)
                {
                    page1.SetActive(true);
                    page2.SetActive(false);
                }
            }
        }
    }
}
