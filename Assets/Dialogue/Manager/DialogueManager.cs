using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] TextMeshProUGUI txt_Dialogue;
    [SerializeField] TextMeshProUGUI txt_Name;
    Dialogue[] dialogues;

    bool isDialogue = false;//대화중 T/F
    bool isNext = false;   //입력대기
    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;
    int lineCount = 0;      //대화 카운트
    int contextCount = 0;   //대사 카운트
    void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isNext = false;
                    txt_Dialogue.text = "";
                    if (++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        contextCount = 0;       //다음 인물의 대사로
                        if (++lineCount < dialogues.Length)
                        {
                            StartCoroutine (TypeWriter());
                        }
                        else                    //대사끝나면
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
        isDialogue=false;
        contextCount = 0;
        lineCount = 0;
        dialogues=null;
        SettingUI(false);
    }
    IEnumerator TypeWriter()
    {
        SettingUI(true);
        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ","); //엑셀상에서 ' -> ,

        
        txt_Name.text=dialogues[lineCount].name;
        for (int i = 0; i < t_ReplaceText.Length; i++)
        {
            txt_Dialogue.text += t_ReplaceText[i];
            yield return new WaitForSeconds(textDelay);
        }
        isNext = true;
       

    }
    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }

   
  
}
