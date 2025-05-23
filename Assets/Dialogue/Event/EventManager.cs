using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventManager : MonoBehaviour
{
    [SerializeField] Item 곶감;
    [SerializeField] Item 떡;
    [SerializeField] Item 위패;
    [SerializeField] Item 호리병;
    [SerializeField] Item 양초;
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
                Debug.Log("떡 먹기");
                inventory.AddItem(곶감);
                break;
            case "eat_gam":
                Debug.Log("곶감 먹기");
                inventory.UseItem("곶감");
                break;
            case "use_위패":
                inventory.UseItem("위패");
                break;
            case "use_호리병":
                inventory.UseItem("호리병");
                break;
            case "use_양초":
                inventory.UseItem("양초");
                break;
            case "get_dduck":
                inventory.AddItem(떡);
                break;
            case "get_gam":
                inventory.AddItem(곶감);
                break;
            case "get_위패":
                inventory.AddItem(위패);
                break;
            case "get_호리병":
                inventory.AddItem(호리병);
                break;
            case "get_양초":
                inventory.AddItem(양초);
                break;
                
        }
    }
}
