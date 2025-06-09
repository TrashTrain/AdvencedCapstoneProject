using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play("Opening");
    }

}
