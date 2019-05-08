using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public GameObject poupeeVaudouPrefab;
    public GameObject vfxDeath;
    [HideInInspector]
    public Transform myTarget;

    [HideInInspector]
    public bool isKilled = false;

    public virtual void Start()
    {
        myTarget = PlayerManager.s_Singleton.transform;
    }

    public virtual void Update()
    {
        if (myTarget.position.x > transform.position.x)
        {
            Vector3 tmpRot = new Vector3(0f, 180f, 0f);
            transform.rotation = Quaternion.Euler(tmpRot);
        }
        else if (myTarget.position.x < transform.position.x)
        {
            Vector3 tmpRot = new Vector3(0f, 0, 0f);
            transform.rotation = Quaternion.Euler(tmpRot);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.s_Singleton.Hit();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Louche"))
        {
            isKilled = true;
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        Destroy(Instantiate(vfxDeath, transform.position, Quaternion.identity), 0.8f);
        if (isKilled)
        {
            GameObject voodooDoll = Instantiate(poupeeVaudouPrefab, gameObject.transform.position, Quaternion.identity);
            PlayerManager.s_Singleton.AddVoodooDoll(voodooDoll.GetComponent<VoodooDoll>());
        }
    }
}