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
    public Item Á¾;
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
                SoundManager.Instance.Play("²Ü²©");
                break;
            case "eat_dduck":
                Debug.Log("¶± ¸Ô±â");
                inventory.UseItem("¶±");
                break;
            case "eat_gam":
                Debug.Log("°ù°¨ ¸Ô±â");
                inventory.UseItem("°ù°¨");
                break;
            case "use_À§ÆÐ":
                inventory.UseItem("À§ÆÐ");
                break;
            case "use_È£¸®º´":
                inventory.UseItem("È£¸®º´");
                break;
            case "use_¾çÃÊ":
                inventory.UseItem("¾çÃÊ");
                break;
            case "get_dduck":
                inventory.AddItem(¶±);
                break;
            case "get_gam":
                inventory.AddItem(°ù°¨);
                break;
            case "get_À§ÆÐ":
                inventory.AddItem(À§ÆÐ);
                break;
            case "get_È£¸®º´":
                inventory.AddItem(È£¸®º´);
                break;
            case "get_¾çÃÊ":
                inventory.AddItem(¾çÃÊ);
                break;
            case "sleep":
                GameMgr.Instance.SceneLoader("InGameSceneTest");
                break;
            case "clickSound":
                SoundManager.Instance.Play("Å¬¸¯");
                break;
                
        }
    }
}
