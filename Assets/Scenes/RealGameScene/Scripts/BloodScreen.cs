using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodScreen : MonoBehaviour
{

    [Header("Player Health")]
    [SerializeField] private float playerMaxHealth = 3f;
    public float playercurrentHealth = 3f;


    [Header("Hurt Image Flash")]
    [SerializeField] private Image hurtImage = null;


    private void UpdateHealth()
    {
        playercurrentHealth--;
    }

    IEnumerator HurtFlash()
    {
        hurtImage.enabled = true;
        yield return new WaitForSeconds(0.3f);
        hurtImage.enabled = false;
    }

    public void TakeDamage()
    {
        if(playercurrentHealth > 0)
        {
            StartCoroutine(HurtFlash());
            UpdateHealth();
        }
    }
}
