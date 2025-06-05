using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public Inventory inven;

    public GameObject endingObject;
    public void OnEnding()
    {
        inven.UseItem("양초");
        inven.UseItem("위패");
        inven.UseItem("호리병");
        // 3등분해서 각각 있는것만 나올 수 있게 수정하기.
        endingObject.SetActive(true);

        RenderSettings.fog = false;
    }
}
