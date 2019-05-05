using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : Ennemy
{

    private Transform myTarget;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        myTarget = PlayerManager.s_Singleton.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, myTarget.position, speed * Time.deltaTime);
        }
    }
}
