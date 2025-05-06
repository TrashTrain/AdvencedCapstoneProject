using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestLevelChanger : MonoBehaviour
{
    public TMP_InputField changeText;
    public void OnClickLevelChanger()
    {
        PlayerTest player = GameMgr.Instance.PlayerInit();
        player.SetBoundaryLevel(int.Parse(changeText.text));
        Debug.Log(player.GetBoundaryLevel());
    }
}
