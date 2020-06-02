using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public int questNumber = 0;
    GameObject journal;
    
    public bool finishedQuest0;
    public bool finishedQuest1;
    public bool finishedQuest2;
    public bool finishedQuest3;
    public bool finishedQuest4;

    public bool gfClock_fixed;
    public bool manClock_fixed;
    public bool cooClock_fixed;
    public bool alClock_fixed;
    private void Start()
    {
        journal = GameObject.Find("/First Person Player/Main Camera/CameraUICan/Journal").gameObject;
        finishedQuest0 = false;
        finishedQuest1 = false;
        finishedQuest2 = false;
        finishedQuest3 = false;
        finishedQuest4 = false;
        
        gfClock_fixed = false;
        manClock_fixed = false;
        cooClock_fixed = false;
        alClock_fixed = false;
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
            quest1();
            
        }

        if (questNumber == 2)
        {
            //do quest number 2 things
            quest2();
        }

        if (questNumber == 3)
        {
            //do quest number 3 things
            quest3();
        }

        if (questNumber == 4)
        {
            //do quest number 4 things
            quest4();
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

        // If all tasks are done in quest 1 are finished then change bool to say quest1 is finished
        if (gfClock_fixed)
        {
            finishedQuest1 = true;
        }

        // If quest 1 is finished, then do ending tasks and move onto next quest
        if (finishedQuest1)
        {
            // No ending actions here

            // move onto next quest
            questNumber += 1;
        }

    }

    public void quest2()
    {
        // Start quest 2
        // Enable entry 2
        journal.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);

        // If all tasks are done in quest 2 then change bool to say quest 2 is finished
        if (manClock_fixed)
        {
            finishedQuest2 = true;
        }

        // If quest 2 is finished then do ending tasks and then move onto next quest
        if (finishedQuest2)
        {

            // move onto next quest
            questNumber += 1;
        }
    }

    public void quest3()
    {
        // Start quest
        // Enable entry 3
        journal.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);

        // If all tasks are done in quest # then change bool to say quest # is finished
        if (cooClock_fixed)
        {
            finishedQuest3 = true;
        }

        // If quest # is finished then do ending tasks and then move onto next quest
        if (finishedQuest3)
        {

            // move onto next quest
            questNumber += 1;
        }
    }

    public void quest4()
    {
        // Start quest
        // Enable entry 4
        journal.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);



        // Enable wind up key if all candles are lit
        if (candles_lit = 10)
        {
            GameObject.Find("/WindUpKey").SetActive(true);
            // Play glug noise
        }


        // If all tasks are done in quest # then change bool to say quest # is finished
        if (alClock_fixed)
        {
            finishedQuest4 = true;
        }

        // If quest # is finished then do ending tasks and then move onto next quest
        if (finishedQuest4)
        {

            //load GO scene
            SceneManager.LoadScene("Game_Over");
        }
    }
}
