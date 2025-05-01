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
            { Debug.Log("선택지입니다.");
                dialogue.isChoice = true;
                dialogue.contexts = new string[] { "" };
                dialogue.choice1 = row[3];
                dialogue.choice1_Next = int.Parse(row[4]);
                dialogue.choice2 = row[5];
                dialogue.choice2_Next = int.Parse(row[6]);
                if (row.Length > 7 && !string.IsNullOrEmpty(row[7]) && !string.IsNullOrEmpty(row[8]))
                {
                    dialogue.choice3 = row[7];
                    dialogue.choice3_Next = int.Parse(row[8]);
                }

                dialougeList.Add(dialogue);
                i++;

            }
            else
            {
                dialogue.name = row[1];     //등장인물 이름
                List<string> contextList = new List<string>();
                int parsedSkipLine=0;
                if (row.Length > 9 && !string.IsNullOrEmpty(row[9]))
                {
                    int.TryParse(row[9], out parsedSkipLine);
                }

                do
                {
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
