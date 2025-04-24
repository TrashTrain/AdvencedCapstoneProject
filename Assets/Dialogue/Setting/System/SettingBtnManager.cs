using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtnManager : MonoBehaviour
{
    public GameObject SettingPanel;
    private bool isOpen;

    public Sprite setting;
    public Sprite close;

    private Image buttonImage;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = setting;

        SettingPanel.SetActive(false);
        isOpen = false;
    }
    public void manageSettingPanel()
    {
        if (isOpen == false)
        {
            SettingPanel.SetActive(true);
            isOpen = true;
            buttonImage.sprite = close;
        }
        else if (isOpen == true)
        {
            SettingPanel.SetActive(false);
            isOpen=false;
            buttonImage.sprite = setting;
        }
    }

    
}
