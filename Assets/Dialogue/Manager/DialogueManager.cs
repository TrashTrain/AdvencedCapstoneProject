using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] public TextMeshProUGUI txt_Dialogue;
    [SerializeField] TextMeshProUGUI txt_Name;

    [SerializeField] GameObject go_ChoicePanel;
    [SerializeField] Button btn_Choice1;
    [SerializeField] Button btn_Choice2;
    [SerializeField] Button btn_Choice3;
    [SerializeField] TextMeshProUGUI txt_Choice1;
    [SerializeField] TextMeshProUGUI txt_Choice2;
    [SerializeField] TextMeshProUGUI txt_Choice3;

    [SerializeField] Image DialNextImage;
    Dialogue[] dialogues;

    bool isDialogue = false;//대화중 T/F
    bool isNext = false;   //입력대기
    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;
    public int lineCount = 0;      //대화 카운트
    int contextCount = 0;   //대사 카운트
   

    string lastSpeaker = "";
    string lastDialogue = "";
    private void Start()
    {
        go_ChoicePanel.SetActive(false);

    }
    void Update()
    {
        if (isDialogue)
        {

            if (isNext && !dialogues[lineCount].isChoice) // 선택지일 땐 무시
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isNext = false;
                    DialNextImage.gameObject.SetActive(false);
                    txt_Dialogue.text = "";

                    if (++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        contextCount = 0;
                        if (dialogues[lineCount].skipLine != 0)
                        {
                            lineCount = dialogues[lineCount].skipLine - 1; // CSV 기준이 1부터일 경우 -1 해줘야 맞음
                        }
                        else
                        {
                            lineCount++;
                        }

                        if (lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        else
                        {
                            EndDialogue();
                            

                        }
                    }
                }
            }
        }
    }
    public void ShowDialogue(Dialogue[] P_dialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = P_dialogues;
        SettingUI(true);
        StartCoroutine(TypeWriter());

    }
    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        SettingUI(false);
    }
    IEnumerator TypeWriter()
    {


        if (lineCount >= dialogues.Length)
        {
            EndDialogue();
            yield break;
        }
        
        EventManager.Instance.TriggerEvent(dialogues[lineCount].eventKey);
        
        SettingUI(true);
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ","); //엑셀상에서 ' -> ,


        txt_Name.text = dialogues[lineCount].name;

        for (int i = 0; i < t_ReplaceText.Length; i++)
        {

            txt_Dialogue.text += t_ReplaceText[i];
            lastDialogue = txt_Dialogue.text;
            lastSpeaker = txt_Name.text;
            yield return new WaitForSeconds(textDelay);
        }
        if (lineCount + 1 < dialogues.Length && dialogues[lineCount + 1].isChoice == true)    //다음 대사가 선택지면 space 스킵해 바로 다음 대사(선택지)로
        {
            lineCount++;
            contextCount = 0;
           // StartCoroutine(TypeWriter());
          
        }
        if (dialogues[lineCount].isChoice)
        {
            ShowChoice();
            DialNextImage.gameObject.SetActive(true);

        }

        else
        {
            isNext = true;
            DialNextImage.gameObject.SetActive(true);
        }



    }
    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }
    void ShowChoice()
    {
        go_ChoicePanel.SetActive(true);
       
        txt_Name.text = lastSpeaker;
        txt_Dialogue.text = lastDialogue;

        if (!string.IsNullOrEmpty(dialogues[lineCount].choice3))
        {
            txt_Choice3.text = dialogues[lineCount].choice3;
            btn_Choice3.gameObject.SetActive(true);
            btn_Choice3.onClick.RemoveAllListeners();
            btn_Choice3.onClick.AddListener(() => {
                OnChoiceSelected(dialogues[lineCount].choice3_Next);
                
                    EventManager.Instance.TriggerEvent(dialogues[lineCount - 1].choice3_Event);
                
            });
        }
        else
        {
            btn_Choice3.gameObject.SetActive(false);
        }



        txt_Choice1.text = dialogues[lineCount].choice1;
        txt_Choice2.text = dialogues[lineCount].choice2;


        btn_Choice1.onClick.RemoveAllListeners();
        btn_Choice2.onClick.RemoveAllListeners();


        btn_Choice1.onClick.AddListener(() => {
            OnChoiceSelected(dialogues[lineCount].choice1_Next);
            //dialogues[lineCount].choice1_Event = "eat_dduck";
            Debug.Log(lineCount);
            
                EventManager.Instance.TriggerEvent(dialogues[lineCount-1].choice1_Event);
            
           
        });
        btn_Choice2.onClick.AddListener(() => {
            OnChoiceSelected(dialogues[lineCount].choice2_Next);
            
                EventManager.Instance.TriggerEvent(dialogues[lineCount - 1].choice2_Event);
            
        });


    }
    void OnChoiceSelected(int nextLine)
    {
        go_ChoicePanel.SetActive(false);
        lineCount = nextLine - 1;
        contextCount = 0;
        txt_Dialogue.text = "";
        //Debug.Log(nextLine);
        StartCoroutine(TypeWriter());
        DialNextImage.gameObject.SetActive(false);
    }
   
   
}
