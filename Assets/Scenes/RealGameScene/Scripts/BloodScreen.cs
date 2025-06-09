using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodScreen : MonoBehaviour
{

    [Header("Player Health")]
    [SerializeField] private float playerMaxHealth = 3f;
    public float playercurrentHealth = 3f;

    [Header("Hurt Splatter Image")]
    [SerializeField] private Image splatterImage = null;

    [Header("Hurt Image Flash")]
    [SerializeField] private Image hurtImage = null;


    private void UpdateHealth()
    {
        playercurrentHealth--;
        Color splatterAlpha = splatterImage.color;
        splatterAlpha.a = 1 - (playercurrentHealth / playerMaxHealth);
        splatterImage.color = splatterAlpha;

    }

    IEnumerator HurtFlash()
    {
        hurtImage.enabled = true;
        yield return new WaitForSeconds(0.1f);
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
