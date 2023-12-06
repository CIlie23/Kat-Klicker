using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankStuff : MonoBehaviour {

    public float timeLimit = 30f; // Set the initial time limit in seconds
    public float timer;
    public Text actualRank;

    // Use this for initialization
    void Start () {
        // Initialize the Mathf.Ceil(timer)
        timer = timeLimit;
    }
	
	// Update is called once per frame
	void Update () {
        // Update the Mathf.Ceil(timer)
        if (Mathf.Ceil(timer) > 0f)
        {
            timer -= Time.deltaTime; // Decrease the Mathf.Ceil(timer) by the time passed since the last frame
           // Debug.Log("Time left: " + Mathf.Ceil(Mathf.Ceil(timer))); // Log the time left (rounded up to the nearest second) stupid ahh math
        }
        else
        {
            //Debug.Log("Click harder"); // cand timpul ajunge la 0
        }

        if (Mathf.Ceil(timer) == 0) //Hi ilie from the future, remember to make the rank system better, thank you i hate you, you stupid piece of shit <3
        {
            actualRank.text = "-";
        }
        else if (Mathf.Ceil(timer) == 20)
        {
            actualRank.text = "D";
        }
        else if (Mathf.Ceil(timer) == 40)
        {
            actualRank.text = "C";
        }
        else if (Mathf.Ceil(timer) == 60)
        {
            actualRank.text = "B";
        }
        else if (Mathf.Ceil(timer) == 80)
        {
            actualRank.text = "A";
        }
        else if (Mathf.Ceil(timer) == 100)
        {
            actualRank.text = "S";
        }
        else if (Mathf.Ceil(timer) == 120)
        {
            actualRank.text = "SS";
        }
        else if (Mathf.Ceil(timer) == 140)
        {
            actualRank.text = "SSS";
        }
        else if (Mathf.Ceil(timer) > 190)
        {
            actualRank.text = "ULTRACOOKIE";
        }
    }

    public void IncreaseTimerByTen()
    {
        timer += 1f;
        //Debug.Log("Timer increased by 10 seconds. New time: " + Mathf.Ceil(timer));
    }
}
