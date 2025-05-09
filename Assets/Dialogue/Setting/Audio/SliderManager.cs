using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public AudioType type;

    void Start()
    {
        Slider slider = GetComponent<Slider>();
        AudioManager.instance.RegisterSlider(type, slider);
    }
}
