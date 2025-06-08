using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TutorialEvent : MonoBehaviour
{
    public int eventNum;
    public static bool dialogEnd;
    ParticleSystem particle;


    private void Start()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Tutorial.tutorialIdx == eventNum && !particle.isPlaying)
        {
            Debug.Log("파티클 실행");
            particle.Play();
        }
        
    }
}
