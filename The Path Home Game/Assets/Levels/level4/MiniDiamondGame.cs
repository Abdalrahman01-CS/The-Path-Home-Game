using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniDiamondGame : MonoBehaviour
{
    public GameObject puzzlePanel; // Assign your puzzle panel here
    public GameObject bigDiamond;  // Assign your final diamond image here

    void Start()
    {
        puzzlePanel.SetActive(false);
        bigDiamond.SetActive(false);
    }

    // Call this when all diamonds are collected
    public void ActivatePuzzle()
    {
        puzzlePanel.SetActive(true);
    }

    // Call this when all small diamonds are placed correctly
    public void ShowBigDiamond()
    {
        bigDiamond.SetActive(true);
        // optional: play animation or sound here
    }
}

