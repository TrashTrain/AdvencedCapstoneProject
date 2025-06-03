using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionEvent : MonoBehaviour
{
    
   
    [SerializeField] DialogueEvent dialogue;

    public GameObject button;
    public bool checkDestroy = false;

    [SerializeField]private DialogueManager dialogueManager;

    private void Start()
    {
        if (dialogue != null)
        {
            dialogue.dialogues = GetDialogue();
        }
//        dialogueManager = FindObjectOfType<DialogueManager>();
        //if (dialogueManager != null)
        //{
        //    dialogueManager.ShowDialogue(dialogue.dialogues);
            
        //}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            button.SetActive(true);
            if (Tutorial.tutorialIdx == 0)
            {
                button.SetActive(false);
                TestPlayer.isPlayerMove = false;
                dialogueManager.ShowDialogue(dialogue.dialogues, gameObject);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            TestPlayer.isPlayerJump = false;
            dialogue.dialogues = GetDialogue();

            //vr
            //button.GetComponent<Button>().onClick.AddListener(() =>
            //{
            //    button.SetActive(false);
            //    TestPlayer.isPlayerMove = false;
            //    dialogueManager.ShowDialogue(dialogue.dialogues);
            //});

            if (Input.GetKeyDown(KeyCode.Space))
            {
                button.SetActive(false);
                TestPlayer.isPlayerMove = false;
                dialogueManager.ShowDialogue(dialogue.dialogues, gameObject);
            }
        }
        else
        {
            button.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        TestPlayer.isPlayerJump = true;
        button.SetActive(false);
    }

    public Dialogue[] GetDialogue()
    {
        dialogue.dialogues=DasabaseManager.instance.GetDialogue(dialogue.csvFileName,(int)dialogue.line.x,(int)dialogue.line.y);
        return dialogue.dialogues;
    }
}
