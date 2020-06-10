using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public int questNumber = 0;
    GameObject journal;
    public int candles_lit = 0;
    bool play_once = false;
    public bool play_uno = false;

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
            if (!play_uno)
            {
                // Start quest 0
                startQuest0();
                play_uno = true;
            }
            //do quest number 0 things
            quest0();
        }

        if (questNumber == 1)
        {
            if (!play_uno)
            {
                startQuest1();
                play_uno = true;
            }
            //do quest number 1 things
            quest1();
            
        }

        if (questNumber == 2)
        {
            if (!play_uno)
            {
                startQuest2();
                play_uno = true;
            }
            //do quest number 2 things
            quest2();
        }

        if (questNumber == 3)
        {
            if (!play_uno)
            {
                startQuest3();
                play_uno = true;
            }
            //do quest number 3 things
            quest3();
        }

        if (questNumber == 4)
        {
            if (!play_uno)
            {
                startQuest4();
                play_uno = true;
            }
            //do quest number 4 things
            quest4();
        }
    }


    public void startQuest0()
    {
        // Start quest 0
        // Nothing required to start this quest
    }

    // Checks to see if you have done the tasks in quest0
    public void quest0()
    {

        // If all tasks in quest 0 are finished then change bool to say quest0 is finished
        if (GameObject.Find("Main Camera/hand").GetComponent<ItemPickUp>().hasJournal && GameObject.Find("Main Camera/hand").GetComponent<ItemPickUp>().hasLighter)
        {
            finishedQuest0 = true;
        }

        // If quest0 is finished then do ending tasks and move onto next quest
        if (finishedQuest0)
        {
            // Unlock master door
            //GameObject.Find("/bedroomDoor").gameObject.GetComponent<Doors>().unlocked = true;
            GameObject.Find("/bedroomDoor").gameObject.GetComponent<DoorProperties>().unlocked = true;
            // move onto next quest
            questNumber += 1;
            play_uno = false;
            Debug.Log("quest0 done"); //DEBUG
        }
        
    }

    public void startQuest1()
    {
        // Start quest 1
        // Enable entry 1
        journal.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("First Person Player/Main Camera/CameraUICan").gameObject.GetComponent<AudioSource>().Play();
    }

    // Checks to see if you have done the tasks in quest1
    public void quest1()
    {
        

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
            play_uno = false;
            Debug.Log("quest1 done"); //DEBUG
        }

    }

    // Starts quest2
    public void startQuest2()
    {
        // Start quest 2
        // Enable entry 2
        journal.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("First Person Player/Main Camera/CameraUICan").gameObject.GetComponent<AudioSource>().Play(0);
    }

    // Checks to see if you have done the tasks in quest2
    public void quest2()
    {
        

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
            play_uno = false;
        }
    }

    // Starts quest3
    public void startQuest3()
    {
        // Start quest
        // Enable entry 3
        journal.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("First Person Player/Main Camera/CameraUICan").gameObject.GetComponent<AudioSource>().Play();
    }

    // Checks to see if you have done the tasks in quest3
    public void quest3()
    {


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
            play_uno = false;
        }
    }

    // Starts quest4
    public void startQuest4()
    {
        // Start quest
        // Enable entry 4
        journal.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("First Person Player/Main Camera/CameraUICan").gameObject.GetComponent<AudioSource>().Play();
    }

    // Checks to see if you have done the tasks in quest4
    public void quest4()
    {



        
        // Enable wind up key if all candles are lit
        if (candles_lit == 13 && ! play_once)
        {
            Debug.Log("WindUpKey is ALLLIIIIIVE");
            GameObject.Find("WindUpKeyHolder").gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // Play glug noise

            play_once = true;
        }


        // If all tasks are done in quest # then change bool to say quest # is finished
        if (alClock_fixed)
        {
            finishedQuest4 = true;
        }

        // If quest # is finished then do ending tasks and then move onto next quest
        if (finishedQuest4)
        {
            play_uno = false;
            //load GO scene
            SceneManager.LoadScene("Game_Over");
        }
    }
}
