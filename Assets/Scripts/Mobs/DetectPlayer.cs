using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public GameObject spider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spider.GetComponent<SpiderManager>().IsGoingDown = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
