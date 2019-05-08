using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public GameObject spider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spider.GetComponent<SpiderManager>().GoDown();
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
