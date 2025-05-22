using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource etcSource;

    [SerializeField] private List<SoundData> soundLibrary;

    private Dictionary<string, SoundData> soundDict = new();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (var sound in soundLibrary)
        {
            soundDict[sound.soundKey] = sound;
        }
    }

    public void Play(string soundKey)
    {
        if (!soundDict.ContainsKey(soundKey))
        {
            Debug.LogWarning("사운드 없음: " + soundKey);
            return;
        }

        var data = soundDict[soundKey];

        AudioSource targetSource = sfxSource;

        if (data.mixerGroup.name == "BGM") targetSource = bgmSource;
        else if (data.mixerGroup.name == "Voice") targetSource = etcSource;
        else if (data.mixerGroup.name == "Effect") targetSource = sfxSource;

        targetSource.outputAudioMixerGroup = data.mixerGroup;
        targetSource.clip = data.clip;
        targetSource.loop = data.loop;
        targetSource.Play();
    }

    public void Stop(string soundKey)
    {
        if (!soundDict.ContainsKey(soundKey))
        {
            Debug.LogWarning("사운드 없음: " + soundKey);
            return;
        }

        var data = soundDict[soundKey];

        AudioSource targetSource = sfxSource;

        if (data.mixerGroup.name == "BGM") targetSource = bgmSource;
        else if (data.mixerGroup.name == "Voice") targetSource = etcSource;
        else if (data.mixerGroup.name == "Effect") targetSource = sfxSource;

        targetSource.outputAudioMixerGroup = data.mixerGroup;
        targetSource.clip = data.clip;
        targetSource.loop = data.loop;
        targetSource.Stop();
    }
}
