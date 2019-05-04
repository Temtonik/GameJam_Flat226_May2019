using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoodooDoll : MonoBehaviour
{
    public bool isAbsorbed = false;

    float speed = 1;

    void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        if (isAbsorbed)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerManager.s_Singleton.transform.position, speed * Time.deltaTime);
        }
    }
}
