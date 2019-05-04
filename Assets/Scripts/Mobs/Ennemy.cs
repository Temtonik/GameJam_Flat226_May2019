using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public GameObject poupeeVaudouPrefab;

    private bool isKilled = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.CompareTag("Louche"))
        {
            isKilled = true;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (isKilled)
        {
            GameObject poupeeVaudou = Instantiate(poupeeVaudouPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}