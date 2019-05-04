using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{

    public GameObject prefab;
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject mob = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
