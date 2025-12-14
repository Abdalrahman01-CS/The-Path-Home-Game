using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DiamondUI : MonoBehaviour
{
    public TextMeshProUGUI diamondText; // Drag your TextMeshProUGUI here
    public int totalDiamonds = 4;

    private int collectedDiamonds = 0;
    public MiniDiamondGame miniGame;
    void Start()
    {
        UpdateDiamondUI();
    }

    public void CollectDiamond()
{
    collectedDiamonds++;
    UpdateDiamondUI();

    if (collectedDiamonds >= totalDiamonds && miniGame != null)
    {
        miniGame.ActivatePuzzle();
    }
}
    void UpdateDiamondUI()
    {
        int remaining = totalDiamonds - collectedDiamonds;
        diamondText.text = remaining.ToString();
    }
}
