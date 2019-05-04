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
            if (PlayerManager.s_Singleton.VoodooDolls.Count > 0)
            {
                PlayerManager.s_Singleton.VoodooDolls.RemoveAt(PlayerManager.s_Singleton.VoodooDolls.Count - 1);
            }
            else
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
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
            GameObject voodooDoll = Instantiate(poupeeVaudouPrefab, gameObject.transform.position, Quaternion.identity);
            voodooDoll.AddComponent<VoodooDoll>();
        }
    }
}