using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioFromAudioManager : MonoBehaviour
{
    public string target;

    public void Play()
    {
        AudioManager_test.instance.Play(target);
    }

    public void Play(string audioName)
    {
        AudioManager_test.instance.Play(audioName);
    }
}
