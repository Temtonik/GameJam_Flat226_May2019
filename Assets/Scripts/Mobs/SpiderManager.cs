using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : Ennemy
{
    public Transform fil;

    private Animator anim;

    public float attackDistance, goDownDistance, speed;

    private Vector2 origin;

    private bool isGoingDown = false;

    public bool IsGoingDown { get => isGoingDown; set => isGoingDown = value; }

    void Start()
    {
        anim = GetComponent<Animator>();
        origin = transform.position;
        anim.SetBool("isIdle", true);

    }

    private void Update()
    {
        if (isGoingDown)
        {
            fil.GetComponent<FilManager>().FollowSpider(transform,origin,speed);

            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed, transform.position.z);

            anim.SetBool("isIdle", false);
            anim.SetBool("isGoingDown", true);
        }
        if (transform.position.y <= origin.y - goDownDistance)
        {
            isGoingDown = false;
            anim.SetBool("isGoingDown", false);
        }
        if(Vector2.Distance(PlayerManager.s_Singleton.transform.position, transform.position) < attackDistance)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", true);
        } else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isIdle", true);
        }
    }
}
