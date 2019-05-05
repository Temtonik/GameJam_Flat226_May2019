using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManager : Ennemy
{
    public Animator anim;

    public float attackDistance, goDownDistance;


    private Vector2 origin;

    private void Awake()
    {
        origin = transform.position;
        anim.SetBool("isGoingDown", true);
    }

    private void Update()
    {
        if(Vector2.Distance(origin,transform.position) >= goDownDistance)
        {
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
