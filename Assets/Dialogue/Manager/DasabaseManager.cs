using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasabaseManager : MonoBehaviour
{
   public static DasabaseManager instance;

 

    Dictionary<string,Dictionary<int, Dialogue>> dialogueDic = new();

    public static bool isFinish = false;

   void Awake()
    {
        if(instance == null)
        {
            instance = this;
           
            isFinish = true;
        }
    }

    public Dialogue[] GetDialogue(string fileName,int _StartNum, int _EndNum)
    {
        if (!dialogueDic.ContainsKey(fileName))
        {
            LoadDialogue(fileName);
        }

        List<Dialogue> dialogueList = new List<Dialogue>();
        var dic = dialogueDic[fileName];

        for (int i = 0; i <= _EndNum - _StartNum; i++)
        {
            int lineNum = _StartNum + i;
            if (dic.ContainsKey(lineNum))
            {
                dialogueList.Add(dic[lineNum]);
            }
            else
            {
               // Debug.LogWarning($"{fileName}의 {lineNum}번째 줄이 존재하지 않습니다.");
            }
        }

        return dialogueList.ToArray();
    }
    private void LoadDialogue(string fileName)
    {
        DialougeParser theParser = GetComponent<DialougeParser>();
        Dialogue[] dialogues = theParser.Parse(fileName);

        Dictionary<int, Dialogue> dic = new Dictionary<int, Dialogue>();
        for (int i = 0; i < dialogues.Length; i++)
        {
            dic.Add(i + 1, dialogues[i]);
        }

        dialogueDic[fileName] = dic;
    }

}
