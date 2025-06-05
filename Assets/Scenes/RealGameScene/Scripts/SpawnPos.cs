using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPos : MonoBehaviour
{
    public Transform originPlayerPos;
    public Transform playerPos;
    void Update()
    {
        transform.position = originPlayerPos.position + playerPos.position + (playerPos.forward * 0.3f);
    }
}
