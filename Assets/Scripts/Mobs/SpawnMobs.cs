using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{

    public GameObject prefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject mob = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
