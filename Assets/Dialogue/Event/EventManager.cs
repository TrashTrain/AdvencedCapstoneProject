using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventManager : MonoBehaviour
{
    [SerializeField] Item °ù°¨;
    [SerializeField] Item ¶±;
    [SerializeField] Item À§ÆÐ;
    [SerializeField] Item È£¸®º´;
    [SerializeField] Item ¾çÃÊ;
    public static EventManager Instance;
    public Inventory inventory;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void Start()
    {
       
    }

    public void TriggerEvent(string eventKey)
    {
        if (string.IsNullOrEmpty(eventKey)) return;

        switch (eventKey)
        {
            case "test_sound":
                SoundManager.Instance.Play("tutorial_bgm");
                break;
            case "eat_dduck":
                Debug.Log("¶± ¸Ô±â");
                SoundManager.Instance.Stop("tutorial_bgm");
                break;
            case "eat_gam":
                Debug.Log("°ù°¨ ¸Ô±â");
                inventory.UseItem("°ù°¨");
                break;
                
        }
    }
}
