using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public enum AudioType { BGM,Effect,Voice }
public class AudioManager : MonoBehaviour
{   
    public static AudioManager instance;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] Button btn_mute;
    [SerializeField] Sprite muteOnImage;
    [SerializeField] Sprite muteOffImage;
    private bool[] isMute=new bool[3];
    private float[] audioVolumes=new float[3];
    private bool isAllMuted = false;
    private Dictionary<AudioType, Slider> sliderMap = new Dictionary<AudioType, Slider>();//�����̴� ����
    private void Awake()
    {
        instance = this;
        

    }
    void Start()
    {
       
        SetAudioVolume(AudioType.BGM, 1.0f);
        SetAudioVolume(AudioType.Effect, 1.0f);
        SetAudioVolume(AudioType.Voice, 1.0f);
    }
    public void RegisterSlider(AudioType type, Slider slider)
    {
        if (!sliderMap.ContainsKey(type))
            sliderMap[type] = slider;

        // ���� �� �����̴� �� ����ȭ
        if (audioMixer.GetFloat(type.ToString(), out float curDB))
        {
            float volumeRatio = Mathf.InverseLerp(-60f, 0f, curDB);
            slider.value = volumeRatio;
        }

        slider.onValueChanged.AddListener((value) => {
            SetAudioVolume(type, value);
        });
    }
    public void SetAudioVolume(AudioType audioType , float volume)
    {
        float dB = Mathf.Lerp(-60f, 0f, volume);
        audioMixer.SetFloat(audioType.ToString(), dB);
        if (sliderMap.ContainsKey(audioType))   //�����̴��� �ݿ�
        {
            var slider = sliderMap[audioType];
            if (Mathf.Abs(slider.value - volume) > 0.001f)
                slider.SetValueWithoutNotify(volume);
        }
    }
    public void SetAudioMute(AudioType audioType)
    {
        int type = (int)audioType;

        if (!isMute[type])
        {
            isMute[type] = true;

            
            if (audioMixer.GetFloat(audioType.ToString(), out float curDB))
            {
                float volumeRatio = Mathf.InverseLerp(-60f, 0f, curDB);
                audioVolumes[type] = volumeRatio;
            }

            SetAudioVolume(audioType, 0.001f); 
        }
        else
        {
            isMute[type] = false;
            SetAudioVolume(audioType, audioVolumes[type]); 
        }
    }
    public void ToggleMuteAll()
    {
       
        if (!isAllMuted)
        {
            
            for (int i = 0; i < 3; i++)
            {
                AudioType type = (AudioType)i;
                if (!isMute[i])
                    SetAudioMute(type);
            }   
            isAllMuted = true;
           btn_mute.GetComponent<Image>().sprite=muteOffImage;
        }
        else
        {
            
            for (int i = 0; i < 3; i++)
            {
                AudioType type = (AudioType)i;
                if (isMute[i])
                    SetAudioMute(type);
            }
            isAllMuted = false;
            btn_mute.GetComponent<Image>().sprite = muteOnImage;
        }
    }

}


