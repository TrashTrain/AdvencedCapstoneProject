using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestLevelChanger : MonoBehaviour
{
    public TMP_InputField changeText;
    //private PlayerTest player = GameMgr.Instance.PlayerInit();
    //public void OnClickLevelChanger()
    //{
    //    player.SetBoundaryLevel(int.Parse(changeText.text));
    //    Debug.Log(player.GetBoundaryLevel());
    //}
    private void Update()
    {
        changeText.text = GameMgr.Instance.PlayerInit().GetBoundaryLevel().ToString();
    }
    public void OnClickLevelUpBtn()
    {
        GameMgr.Instance.PlayerInit().SetUpBoundaryLevel();
        
    }
    public void OnClickLevelDownBtn()
    {
        GameMgr.Instance.PlayerInit().SetDownBoundaryLevel();
        
    }
}
