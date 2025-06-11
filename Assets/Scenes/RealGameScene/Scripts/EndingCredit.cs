using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    public void OnClickFirstScreen()
    {
        GameMgr.Instance.SceneFastLoader("GameStart");
    }
}
