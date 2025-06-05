using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingBtnManager : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject BackGround;
    private bool isOpen;
    public Sprite setting;
    public Sprite close;
    public Button backbtn;
    public Button originbtn;
    
    // Start is called before the first frame update
    void Start()
    {
        
        backbtn.gameObject.SetActive(false);
        SettingPanel.SetActive(false);
        BackGround.gameObject.SetActive(false);
        isOpen = false;
        Debug.Log(isOpen);
    }
    public void manageSettingPanel()
    {
        if (isOpen == false)
        {
            EventManager.Instance.TriggerEvent("clickSound");
            SettingPanel.SetActive(true);
            isOpen = true;
            originbtn.gameObject.SetActive(false);
            backbtn.gameObject.SetActive(true);
            BackGround.gameObject.SetActive(true);

}
        else if (isOpen == true)
        {
            EventManager.Instance.TriggerEvent("clickSound");
            SettingPanel.SetActive(false);
            isOpen=false;
            originbtn.gameObject.SetActive(true);
            backbtn.gameObject.SetActive(false);
            BackGround.gameObject.SetActive(false);
        }
    }

    
}
