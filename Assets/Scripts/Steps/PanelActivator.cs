using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel;
    public float speed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            panel.transform.position = Vector2.MoveTowards(panel.transform.position, collision.transform.position, speed * Time.deltaTime);
        }
    }
}
