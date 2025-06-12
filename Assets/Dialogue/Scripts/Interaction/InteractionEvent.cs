using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class InteractionEvent : MonoBehaviour
{
    
   
    public DialogueEvent dialogue;

    public GameObject button;
    public bool checkDestroy = false;
    public int npcCheckIdx = 0;

    public bool autoPlay = false;
    public float autoDelayTime = 2f;
    private float checkDelayTime = 0f;

    public bool tutorial = false;

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

    private void Update()
    {
        //button.GetComponent<Button>().onClick.AddListener(OnClickDialogStart);
    }

    public void OnClickDialogStart()
    {
        button.SetActive(false);
        TestPlayer.isPlayerMove = false;
        dialogueManager.ShowDialogue(dialogue.dialogues, gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !dialogueManager.isDialogue)
        {
            //dialogueManager.ChangeRayCast();
            if(!autoPlay)
                button.SetActive(true);
            if (Tutorial.tutorialIdx == 0 && other.gameObject.layer == LayerMask.NameToLayer("Tutorial"))
            {
                Debug.Log(Tutorial.tutorialIdx);
                OnClickDialogStart();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            TestPlayer.isPlayerJump = false;
            dialogue.dialogues = GetDialogue();
            if (autoPlay)
            {
                checkDelayTime += Time.deltaTime;
                if (checkDelayTime >= autoDelayTime)
                {
                    checkDelayTime = 0;
                    OnClickDialogStart();
                    autoPlay = false;
                }
            }
            //vr
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                button.SetActive(false);
                TestPlayer.isPlayerMove = false;
                dialogueManager.ShowDialogue(dialogue.dialogues, gameObject);
            });

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnClickDialogStart();
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
