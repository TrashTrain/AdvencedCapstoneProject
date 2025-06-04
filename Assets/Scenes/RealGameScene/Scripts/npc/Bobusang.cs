using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobusang : MonoBehaviour
{

    InteractionEvent npcIndex;

    private void Start()
    {
        npcIndex = gameObject.GetComponent<InteractionEvent>();
}
    void Update()
    {
        if(npcIndex.npcCheckIdx == 1)
        {
            npcIndex.dialogue.csvFileName = "보부상 평소";
        }
    }
}
