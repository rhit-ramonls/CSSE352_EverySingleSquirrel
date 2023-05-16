using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        // Can use a singleton here instead
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnMouseDown()
    {
        // Can use a singleton here instead
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
