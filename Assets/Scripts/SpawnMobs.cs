using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{

    public GameObject prefab;

    private bool cameraEnter;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cameraEnter)
        {
            GameObject mob = (GameObject)Instantiate(prefab);
            mob.transform.position = this.transform.position;
        }
    }
}
