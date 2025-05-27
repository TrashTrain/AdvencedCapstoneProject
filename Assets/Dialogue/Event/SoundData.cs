using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "NewSoundData", menuName = "Sound/SoundData")]
public class SoundData : ScriptableObject
{
    public string soundKey;             
    public AudioClip clip;             
    public AudioMixerGroup mixerGroup;  
    public bool loop;                  
}