using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneTestMgr : MonoBehaviour
{
    public Button StartBtn;

    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Player");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
