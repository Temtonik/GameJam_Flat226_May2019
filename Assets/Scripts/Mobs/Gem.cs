using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gem;
    public GameObject headToDisplay;
    public GameObject vfxTrans;
    private bool isComplete = false;
    public float shootSpeed = 12f;
    private bool isShot = false;
    private AudioSource myAS;
    public AudioClip screamClip;
    private bool playerShotMe = false;
    public string myText;

    private void Start()
    {
        myAS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerShotMe)
        {
            if (!isShot)
            {
                isShot = true;
                myAS.Play();
                DestroyMe();
            }
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, shootSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Louche"))
        {
            if (!isComplete)
            {
                DeactivateCollider();
                CompleteObjective();
            }
            else if (isComplete)
            {
                playerShotMe = true;
                DeactivateCollider();
            }
        }
    }

    public void CompleteObjective()
    {
        gem.SetActive(false);
        headToDisplay.SetActive(true);
        Destroy(Instantiate(vfxTrans, transform.position, Quaternion.identity), 0.8f);
        isComplete = true;
        UIManager.s_Singleton.DisplayDialogueBox(myText, this);
        GetComponent<LittleHeadManager>().UnlockAbility();
    }

    public void ActivateCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public void DeactivateCollider ()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        UIManager.s_Singleton.GetComponent<AudioSource>().Stop();
    }

    public void DestroyMe ()
    {
        UIManager.s_Singleton.AddAHead();
        Destroy(gameObject, 2f);
    }

}