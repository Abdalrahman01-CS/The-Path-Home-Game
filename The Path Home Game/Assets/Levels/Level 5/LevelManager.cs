using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;

    public void Respawn(GameObject player)
    {
        if (CurrentCheckpoint != null)
        {
            player.transform.position = CurrentCheckpoint.transform.position;
        }
        else
        {
            Debug.LogWarning("No checkpoint set!");
        }
    }

}
