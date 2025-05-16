using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestLevelChanger : MonoBehaviour
{
    public TMP_InputField changeText;
    private PlayerTest player = GameMgr.Instance.PlayerInit();
    public void OnClickLevelChanger()
    {
        player.SetBoundaryLevel(int.Parse(changeText.text));
        Debug.Log(player.GetBoundaryLevel());
    }

    public void OnClickLevelUpBtn()
    {
        player.SetUpBoundaryLevel();
        changeText.text = player.GetBoundaryLevel().ToString();
    }
    public void OnClickLevelDownBtn()
    {
        player.SetDownBoundaryLevel();
        changeText.text = player.GetBoundaryLevel().ToString();
    }
}
