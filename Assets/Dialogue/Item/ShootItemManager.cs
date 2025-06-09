using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootItemManager : MonoBehaviour
{
    [SerializeField] private GameObject gamPrefab;
    [SerializeField] private GameObject ddukPrefab;
    [SerializeField] private Transform spawnPos;
    Transform spawn;
    public void UseGam()
    {
        EventManager.Instance.inventory.UseItem("°ù°¨");
        Debug.Log("gamspawn");
        GameObject gam = Instantiate(gamPrefab, spawnPos);
        gam.GetComponent<Transform>().position = spawnPos.position;
        gam.transform.SetParent(null);
        gameObject.SetActive(false);
        StartCoroutine(GravityItem());
        gam.GetComponent<Rigidbody>().useGravity = true;
    }
   public void UseDduck()
    {
        EventManager.Instance.inventory.UseItem("¶±");
        GameObject dduk = Instantiate(ddukPrefab, spawnPos);
        dduk.GetComponent<Transform>().position = spawnPos.position;
        dduk.transform.SetParent(null);
        gameObject.SetActive(false);
        StartCoroutine(GravityItem());
        dduk.GetComponent<Rigidbody>().useGravity = true;
    }
    IEnumerator GravityItem()
    {
        yield return new WaitForSeconds(2f);
    }

}
