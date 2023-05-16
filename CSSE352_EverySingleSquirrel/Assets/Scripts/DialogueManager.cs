using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // original one
// using UnityEngine.UIElements;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject portrait;
    // public Sprite portrait;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        // Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        portrait = dialogue.portrait;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        // Debug.Log(sentence);
        // dialogueText.text = sentence; // This one is if you want the text automatically in text box

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // This one types out the letters one by one
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        // Debug.Log("End of conversation");
    }

}
