using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundORSystem : MonoBehaviour
{
    public GameObject SoundTab;
    public GameObject SystemTab;
    private void Start()
    {
        SoundTab.SetActive(true);
        SystemTab.SetActive(false);
    }
    public void setSystemTab()
    {
        SystemTab.SetActive(true);
        SoundTab.SetActive(false);
    }
    public void setSoundTab()
    {
        SystemTab.SetActive(false);
        SoundTab.SetActive(true);
    }
}
