using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public int questNumber = 0;
    GameObject journal;
    bool finishedQuest0;
    bool finishedQuest1;
    bool finishedQuest2;
    bool finishedQuest3;
    bool finishedQuest4;
    private void Start()
    {
        journal = GameObject.Find("/First Person Player/Main Camera/CameraUICan/Journal").gameObject;
        finishedQuest0 = false;
        finishedQuest1 = false;
        finishedQuest2 = false;
        finishedQuest3 = false;
        finishedQuest4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (questNumber == 0)
        {
            //do quest number 0 things
            quest0();
        }

        if (questNumber == 1)
        {

            //do quest number 1 things
            // Enable entry 2
            journal.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        }

        if (questNumber == 2)
        {
            //do quest number 2 things
            // Enable entry 3
            journal.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        }

        if (questNumber == 3)
        {
            //do quest number 3 things
            // Enable entry 4
            journal.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
        }

        if (questNumber == 4)
        {
            //do quest number 4 things
            //load GO scene
            SceneManager.LoadScene("Game_Over");
        }
    }

    public void quest0()
    {
        // Start quest 0
        // Nothing required to start this quest

        // If all tasks in quest 0 are finished then change bool to say quest0 is finished
        if (GameObject.Find("Main Camera/hand").GetComponent<ItemPickUp>().hasJournal && GameObject.Find("Main Camera/hand").GetComponent<ItemPickUp>().hasLighter)
        {
            finishedQuest0 = true;
        }

        // If quest0 is finished then do ending tasks and move onto next quest
        if (finishedQuest0)
        {
            // Unlock master door
            GameObject.Find("/bedroomDoor").gameObject.GetComponent<Doors>().unlocked = true;

            // move onto next quest
            questNumber += 1;

        }
        
    }

    public void quest1()
    {
        // Start quest 1
        // Enable entry 1
        journal.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }
}
