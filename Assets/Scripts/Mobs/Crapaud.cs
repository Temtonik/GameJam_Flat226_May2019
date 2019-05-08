using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crapaud : Ennemy
{
    public float jumpImpulse = 5f;
    
    private Animator myAnim;
    private bool playerSpotted = false;
    private Rigidbody2D myRb;
    public float jumpGap = 2.5f;
    private AudioSource myAS;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myAS = GetComponent<AudioSource>();
        StartCoroutine("TriggerNewJump");
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (myTarget != null && playerSpotted)
        {
            JumpTowardsPlayer();
        }
    }

    private void JumpTowardsPlayer ()
    {
        playerSpotted = false;
        myRb.AddForce(new Vector3(-transform.right.x * jumpImpulse, Vector3.up.y * jumpImpulse, 0f), ForceMode2D.Impulse);
        myAnim.SetBool("Jump", true);
        myAS.Play();
        StartCoroutine("TriggerNewJump");
    }

    IEnumerator TriggerNewJump ()
    {
        yield return new WaitForSeconds(jumpGap);
        playerSpotted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            myAnim.SetBool("Jump", false);
            myRb.velocity = Vector3.zero;
        }
    }
}
