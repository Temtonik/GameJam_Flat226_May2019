using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooDoll : MonoBehaviour
{
    private bool isAbsorbed = false;

    public float speed = 1;

    void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        if (isAbsorbed)
        {
            Vector3 playerPos = PlayerManager.s_Singleton.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            if (transform.position == playerPos)
            {
                PlayerManager.s_Singleton.EarnASoul();
                Destroy(gameObject);
            }
        }
    }

    public void StartAbsorbtion ()
    {
        isAbsorbed = true;
    }

    public void StopAbsorbtion()
    {
        isAbsorbed = false;
    }
}
