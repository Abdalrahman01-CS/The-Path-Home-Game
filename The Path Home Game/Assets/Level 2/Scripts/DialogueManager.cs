using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject NextButton;
    public TextMeshProUGUI dialogueText;
    public float startTypingDelay = 0.5f;
    public float typingSpeed = 0.02f;

    private string[] dialogueSentences;
    private int index = 0;

    public Rigidbody2D RinRb;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(true);
        NextButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDialogue(string[] sentence)
    {
        this.dialogueSentences = sentence;
    }

    public IEnumerator TypeDialogue()
    {
        dialogueText.text = "";

        RinRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        yield return new WaitForSeconds(startTypingDelay);
        foreach (char letter in dialogueSentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

            if(dialogueText.text == dialogueSentences[index])
            {
                NextButton.SetActive(true);
            }
        }
    }

    public void NextSentence()
    {
        NextButton.SetActive(false);

        if (index < dialogueSentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            dialogueText.text = "";
            dialoguePanel.SetActive(false);
            this.dialogueSentences = null;
            index = 0;
            RinRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
