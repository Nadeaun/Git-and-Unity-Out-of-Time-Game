using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class permission : MonoBehaviour
{
    public bool allowed;

    public bool need_q0;
    public bool need_q1;
    public bool need_q2;
    public bool need_q3;


    // Start is called before the first frame update
    void Start()
    {
        allowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (need_q0)
        {
            if (GameObject.Find("First Person Player").GetComponent<GameStateController>().finishedQuest0)
            {
                allowed = true;
            }
        }

        if (need_q1)
        {
            if (GameObject.Find("First Person Player").GetComponent<GameStateController>().finishedQuest1)
            {
                allowed = true;
            }
        }

        if (need_q2)
        {
            if (GameObject.Find("First Person Player").GetComponent<GameStateController>().finishedQuest2)
            {
                allowed = true;
            }
        }

        if (need_q3)
        {
            if (GameObject.Find("First Person Player").GetComponent<GameStateController>().finishedQuest3)
            {
                allowed = true;
            }
        }

        
    }
}
