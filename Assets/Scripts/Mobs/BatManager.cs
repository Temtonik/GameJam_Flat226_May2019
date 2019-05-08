using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : Ennemy
{
    
    public float speed = 3f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (myTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, myTarget.position, speed * Time.deltaTime);
        }
    }
}
