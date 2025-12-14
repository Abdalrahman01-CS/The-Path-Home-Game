using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirajDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private string[] dialogue = {"The water here is alive… step lightly.",
                                "Use your double jump. Trust yourself."};

    // Start is called before the first frame update
    void Start()
    {
            dialogueManager.SetDialogue(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
