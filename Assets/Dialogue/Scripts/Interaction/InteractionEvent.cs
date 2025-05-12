using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    
   
    [SerializeField] DialogueEvent dialogue;
    private void Start()
    {
        if (dialogue != null)
        {
            dialogue.dialogues = GetDialogue();
        }
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.ShowDialogue(dialogue.dialogues);
            
        }
    }
    public Dialogue[] GetDialogue()
    {
        dialogue.dialogues=DasabaseManager.instance.GetDialogue(dialogue.csvFileName,(int)dialogue.line.x,(int)dialogue.line.y);
        return dialogue.dialogues;
    }
}
