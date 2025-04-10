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
        
        for(int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });       //,단위로 쪼갬

            Dialogue dialogue = new Dialogue();     //대사 리스트 생성
            dialogue.name = row[1];     //등장인물 이름
            

            List<string> contextList = new List<string>();


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
            dialogue.contexts=contextList.ToArray();
            dialougeList.Add(dialogue);
           
        }
        return dialougeList.ToArray();

    }
   
}
