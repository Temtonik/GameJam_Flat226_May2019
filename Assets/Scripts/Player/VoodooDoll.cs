using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooDoll : MonoBehaviour
{
    private bool isAbsorbed = false;
    private Animator myAnim;
    private Transform myTarget;

    public float speed = 1;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        myTarget = PlayerManager.s_Singleton.transform;
    }

    void Update()
    {
        MoveToPlayer();
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

    void MoveToPlayer()
    {
        if (isAbsorbed)
        {
            Vector3 playerPos = PlayerManager.s_Singleton.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            if (transform.position == playerPos)
            {
                PlayerManager.s_Singleton.EarnASoul(this);
                Destroy(gameObject);
            }
        }
    }

    public void StartAbsorbtion ()
    {
        isAbsorbed = true;
        myAnim.SetBool("IsAbsorbed", true);
    }

    public void StopAbsorbtion()
    {
        isAbsorbed = false;
        myAnim.SetBool("IsAbsorbed", false);
    }
}
