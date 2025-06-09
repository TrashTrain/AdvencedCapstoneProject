using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    public void OnClickButton()
    {
        GameMgr.Instance.SceneLoader("InGameSceneTest");
    }
}
