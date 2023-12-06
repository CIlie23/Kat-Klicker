using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    [Header("Achievement buttons")]
    public List<Button> achievementButtons;
    public bool[] achievementsUnlocked = new bool[3] { false, false, false };

    void Start()
    {
        interactible(false);
    }

    void interactible(bool interactable)
    {
        foreach (Button button in achievementButtons)
        {
            button.interactable = interactable;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
