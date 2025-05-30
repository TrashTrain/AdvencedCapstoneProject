using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    private static GameMgr instance = null;
    PlayerTest player = new PlayerTest();
    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameMgr Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }

    }
    public PlayerTest PlayerInit()
    {
        if(player == null)
        {
            player = new PlayerTest();
        }
        return player;
    }

    public void SlowMotion(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
