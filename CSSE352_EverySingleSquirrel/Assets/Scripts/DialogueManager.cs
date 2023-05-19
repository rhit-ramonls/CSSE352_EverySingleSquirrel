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
    // public GameObject dialogueBox;
    private bool introDone = false;
    private bool questDone = false;

    public Animator animator;

    private Queue<string> sentences;

    private string[] names = new string[] {"Sandra", "Daisy", "Nutella", "Pecanessa", "Peanutte", "Hazel", "Chestnut"};

    private bool[] introEnd = new bool[] {false, false, false, false, false, false, false};
    // private bool[] questEnd = new bool[] {false, false, false, false, false, false, false};

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        // dialogueBox = GameObject.Find("DialogueBox");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        // Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        portrait = dialogue.portrait;
        // introDone = false; // shouldn't be here if implementing options, but running out of time

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
            
            for(int i=0; i<names.Length; i++){
                Debug.Log(names[i] + " Compared to " + nameText.text);
                if(string.Equals(names[i], nameText.text) && introEnd[i] == true){
                    if (FindObjectOfType<GameManager>().numAcorns >= 5)
                    {
                    FindObjectOfType<GameManager>().numAcorns = FindObjectOfType<GameManager>().numAcorns - 5;
                    GoodResponse();
                    } else {
                    Debug.Log("Match!");
                    EventBus.Publish(EventBus.EventType.SpawnItems);
                    }
                    EndDialogue();
                    return;
                }
            }
            
            ChangeDialogue();
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

    void ChangeDialogue()
    {
        switch (nameText.text)
        {
            case "Sandra":
                // Debug.Log("Changing Sandra's dialogue");
                introEnd[0] = true;
                GameObject.Find("SquirrelSandra").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Hey! Sorry to bother you with it, but my it seems like my last experiment went wrong and exploded!", "Would you mind helping me pick up some of the pieces?"};
                break;
            case "Daisy":
                introEnd[1] = true;
                GameObject.Find("SquirrelDaisy").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Hey again sweetie!", "The flower shop has been so busy lately! I don't know if I could collect enough flowers before the end of the day.", "Would you be a dear and help me out a bit?"};
                break;
            case "Nutella":
                introEnd[2] = true;
                GameObject.Find("SquirrelNutella").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Oh no! I was just getting ready to bake a pie when I realized that I don't have enough acorns!", "Where am I gonna get some acorns at this hour?"};
                break;
            case "Pecanessa":
                introEnd[3] = true;
                GameObject.Find("SquirrelPecanessa").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Oh hey again dude.", "Those pesky kids from the neighboring town stopped by the bike shop and took all my tools again!", "I have an important client I need to meet this afternoon, do you think you could help me look for them?"};
                break;
            case "Peanutte":
                introEnd[4] = true;
                GameObject.Find("SquirrelPeanutte").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Oh, it's you.", "Hey, while you're here, do you want to help me out with something really quick?", "There was this townssquirrel that lost their pet rock recently, and they're pretty broken up about it.", "You better not laugh, but I drew up these missing posters to hopefully raise some awareness.", "Help me put them up around town?"};
                break;
            case "Hazel":
                introEnd[5] = true;
                GameObject.Find("SquirrelHazel").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Woowee!", "I think it's just about time for harvest season!", "Unfortunately I'm a little shorthanded right now and there's so much to do...", "If you help me out a bit, I'll make it worth your while?"};
                break;
            case "Chestnut":
                introEnd[6] = true;
                GameObject.Find("SquirrelChestnut").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Oh geez... I was studying all over town and ended up leaving the books everywhere!", "I wonder if I'll be able to find them all..."};
                break;
            default:
                Debug.Log("Who am I talking to?");
                break;
        }
    }

    void DisplayOptions()
    {
        // GameObject.Find("Name").SetActive(false);
        // GameObject.Find("Dialogue").SetActive(false);
        GameObject.Find("ContinueButton").SetActive(false);
        GameObject.Find("DialogueOptionsPanel").SetActive(true);

        
        // GameObject.Find("Option1").GetComponentInChildren<Text>().text = "la di da";
    }

    void BadResponse()
    {

    }

    void GoodResponse()
    {
        switch (nameText.text)
        {
            case "Sandra":
                GameObject.Find("SquirrelSandra").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"OMG! Thank you so much!", "This recovery will help me out a ton with my research!"};
                break;
            case "Daisy":
                GameObject.Find("SquirrelDaisy").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Aw thank you so much darling! I really appreciate it!"};
                break;
            case "Nutella":
                GameObject.Find("SquirrelNutella").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"This is exactly what I needed! I'll be sure to give you a slice when I'm done."};
                break;
            case "Pecanessa":
                GameObject.Find("SquirrelPecanessa").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Dude, sick!", "You're a total life saver!"};
                break;
            case "Peanutte":
                GameObject.Find("SquirrelPeanutte").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Oh?", "You actually put up all the flyers?", "Well th-thank you..."};
                break;
            case "Hazel":
                GameObject.Find("SquirrelHazel").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Yeehaw!", "Thanks for all the hard work partner!"};
                break;
            case "Chestnut":
                GameObject.Find("SquirrelChestnut").GetComponent<DialogueTrigger>().dialogue.sentences = new string[] {"Oh! Oh my gosh!", "You found all the books I lost?", "Thank you so much!"};
                break;
            default:
                Debug.Log("Who am I talking to?");
                break;
        }
    }
}
