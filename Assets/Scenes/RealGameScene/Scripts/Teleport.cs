using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("teleport¥Í¿Ω");
        GameMgr.Instance.SceneLoader("InGameSceneTest");
    }
}
