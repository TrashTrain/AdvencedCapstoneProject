using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventManager : MonoBehaviour
{
    [SerializeField] Item ����;
    [SerializeField] Item ��;
    [SerializeField] Item ����;
    [SerializeField] Item ȣ����;
    [SerializeField] Item ����;
    public Item ��;
    public static EventManager Instance;
    public Inventory inventory;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void Start()
    {
        inventory.AddItem(��);
    }

    public void TriggerEvent(string eventKey)
    {
        if (string.IsNullOrEmpty(eventKey)) return;

        switch (eventKey)
        {
            case "test_sound":
                SoundManager.Instance.Play("�ܲ�");
                break;
            case "eat_dduck":
                Debug.Log("�� �Ա�");
                inventory.UseItem("��");
                break;
            case "eat_gam":
                Debug.Log("���� �Ա�");
                inventory.UseItem("����");
                break;
            case "use_����":
                inventory.UseItem("����");
                break;
            case "use_ȣ����":
                inventory.UseItem("ȣ����");
                break;
            case "use_����":
                inventory.UseItem("����");
                break;
            case "get_dduck":
                inventory.AddItem(��);
                break;
            case "get_gam":
                inventory.AddItem(����);
                break;
            case "get_����":
                inventory.AddItem(����);
                break;
            case "get_ȣ����":
                inventory.AddItem(ȣ����);
                break;
            case "get_����":
                inventory.AddItem(����);
                break;
            case "sleep":
                GameMgr.Instance.SceneLoader("InGameSceneTest");
                break;
            case "clickSound":
                SoundManager.Instance.Play("Ŭ��");
                break;
            case "eatSound":
                SoundManager.Instance.Play("�ܲ�");
                break;
                
        }
    }
}
