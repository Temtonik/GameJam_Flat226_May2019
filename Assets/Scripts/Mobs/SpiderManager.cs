using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : Ennemy
{
    public Transform fil;
    private Vector3 destination = Vector3.zero;
    private AudioSource myAS;

    private Animator anim;

    public float attackDistance, goDownDistance, speed;

    private Vector2 origin;

    private bool isGoingDown = false;

    //public bool IsGoingDown { get => isGoingDown; set => isGoingDown = value; }

    public override void Start()
    {
        base.Start();
        myAS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        origin = transform.position;
        anim.SetBool("isIdle", true);

    }

    public override void Update()
    {
        //base.Update();
        if (isGoingDown)
        {
            if (destination == Vector3.zero)
            {
                destination = new Vector3(transform.position.x, myTarget.position.y, transform.position.z);
                anim.SetBool("isIdle", false);
                anim.SetBool("isGoingDown", true);
                anim.SetBool("isAttacking", false);
                myAS.Stop();
            }
            fil.GetComponent<FilManager>().FollowSpider(transform,origin,speed);

            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            if (transform.position == destination)
            {
                isGoingDown = false;
            }
        }
        else if (Vector2.Distance(myTarget.position, transform.position) < attackDistance)
        {
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isGoingDown", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isIdle", true);
            myAS.Stop();
        }
    }

    public void GoDown ()
    {
        isGoingDown = true;
    }
}
