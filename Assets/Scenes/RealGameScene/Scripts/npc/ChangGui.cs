using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangGui : MonoBehaviour
{
    private InteractionEvent npcIndex;
    private Transform trans;

    public Transform pos1;
    public Transform pos2;

    public GameObject door;

    public GameObject tiger;

    public GameObject nextEvent;
    private bool checkAutoPlay = false;
    private void Start()
    {
        npcIndex = gameObject.GetComponent<InteractionEvent>();
        trans = gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        if (npcIndex.npcCheckIdx == 1)
        {
            npcIndex.dialogue.csvFileName = "Ã¢±Í Áý";
            trans.position = new Vector3(pos1.position.x, pos1.position.y, pos1.position.z);
            door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0, 20f, 0), 1f * Time.deltaTime);
        }
        else if(npcIndex.npcCheckIdx == 2)
        {
            npcIndex.dialogue.csvFileName = "Ã¢±Í Áý¹Û";
            trans.position = new Vector3(pos2.position.x, pos2.position.y, pos2.position.z);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            if (!checkAutoPlay)
            {
                checkAutoPlay = true;
                npcIndex.autoPlay = true;
            }
                
            
        }
        else if(npcIndex.npcCheckIdx == 3)
        {
            door.transform.rotation = Quaternion.Lerp(door.transform.rotation, Quaternion.Euler(0, 90f, 0), 1f * Time.deltaTime);
            if(nextEvent.GetComponent<InteractionEvent>().autoPlay)
            {
                tiger.SetActive(true);
                nextEvent.SetActive(true);
                Destroy(gameObject);
            }
            
        }
    }
}
