using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialougeList = new List<Dialogue>(); //대화 리스트 생성
  
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //csv파일 로드

        string[] data = csvData.text.Split(new char[] { '\n' }); //엔터 단위로 쪼갬

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });       //,단위로 쪼갬

            Dialogue dialogue = new Dialogue();     //대사 리스트 생성

            if (row[1].Trim() == "선택지")
            {  
                dialogue.isChoice = true;
                dialogue.contexts = new string[] { "" };
                dialogue.choice1 = row[3];
                dialogue.choice1_Next = int.Parse(row[4]);
                dialogue.choice1_Event = row[5].Trim();
                dialogue.choice2 = row[6];
                dialogue.choice2_Next = int.Parse(row[7]);
                dialogue.choice2_Event = row[8].Trim();
                dialogue.choice3 = row[9];
                //dialogue.choice3_Next = int.Parse(row[10]);
                int.TryParse(row[10], out dialogue.choice3_Next);
                dialogue.choice3_Event = row[11].Trim();
                

                dialougeList.Add(dialogue);
                i++;

            }
            else
            {
                dialogue.name = row[1];     //등장인물 이름
                List<string> contextList = new List<string>();
                int parsedSkipLine = 0;
                if (row.Length > 12 && !string.IsNullOrEmpty(row[12]))
                {
                    int.TryParse(row[12], out parsedSkipLine);
                }
                if (row.Length > 13 && !string.IsNullOrEmpty(row[13]))
                {
                    dialogue.eventKey = row[13].Trim();
                }

                do
                {
                    if (row.Length > 2)
                        contextList.Add(row[2]);

                    if (++i < data.Length)
                    {
                        row = data[i].Split(new char[] { ',' });
                    }
                    else
                    {
                        break;
                    }
                } while (row[0].ToString() == "");
                dialogue.contexts = contextList.ToArray();
                dialogue.skipLine = parsedSkipLine;
                dialougeList.Add(dialogue);

            }
        }
        return dialougeList.ToArray();

    }

}
