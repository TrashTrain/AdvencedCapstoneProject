using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public Inventory inven;

    public GameObject endingObject;
    public void OnEnding()
    {
        inven.UseItem("����");
        inven.UseItem("����");
        inven.UseItem("ȣ����");
        // 3����ؼ� ���� �ִ°͸� ���� �� �ְ� �����ϱ�.
        endingObject.SetActive(true);

        RenderSettings.fog = false;
        gameObject.GetComponent<InteractionEvent>().OnClickDialogStart();
    }
}
