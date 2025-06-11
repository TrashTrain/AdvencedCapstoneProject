using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play("MainBGM");
    }
}
