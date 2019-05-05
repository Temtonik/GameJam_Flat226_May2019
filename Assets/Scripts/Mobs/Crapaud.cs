using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crapaud : Ennemy
{
    public float jumpImpulse = 5f;
    private Transform myTarget;
    private Animator myAnim;
    private bool playerSpotted = false;
    private Rigidbody2D myRb;

    // Start is called before the first frame update
    void Start()
    {
        myTarget = PlayerManager.s_Singleton.transform;
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            playerSpotted = true;
        }

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
        
        if (myTarget != null && playerSpotted)
        {
            playerSpotted = false;
            myRb.AddForce(new Vector3(-transform.right.x * jumpImpulse, Vector3.up.y * jumpImpulse, 0f), ForceMode2D.Impulse);
            myAnim.SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            myAnim.SetBool("Jump", false);
        }
        
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
}
