using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public const string X_POSITION = "x_position";
    public const string Y_POSITION = "y_position";



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat(X_POSITION, transform.position.x);
            PlayerPrefs.SetFloat(Y_POSITION, transform.position.y);
            PlayerPrefs.Save();
            GetComponent<BoxCollider2D>().enabled = false;
            PlayerManager.s_Singleton.UpdateSpawnPoint();
        }
    }
}
