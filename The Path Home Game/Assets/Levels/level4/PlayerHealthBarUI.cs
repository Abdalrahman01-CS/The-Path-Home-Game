using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    public Sprite[] barSprites;      

    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void UpdateHealthBar(int current, int max)
    {
    if (barSprites == null || barSprites.Length == 0) return;

    float percent = (float)current / max;

    int index = Mathf.RoundToInt(percent * (barSprites.Length - 1));
    index = Mathf.Clamp(index, 0, barSprites.Length - 1);

    image.sprite = barSprites[index];
    }

}
