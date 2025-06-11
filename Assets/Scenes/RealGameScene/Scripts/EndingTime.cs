using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeStop());
    }
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(1f);
        GameMgr.Instance.SlowMotion(0);
    }
}
