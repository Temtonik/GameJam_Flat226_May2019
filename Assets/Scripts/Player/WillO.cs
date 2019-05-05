using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillO : MonoBehaviour
{
    public float speed = 6f;
    private Transform myTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, myTarget.position, speed * Time.deltaTime);
        }
    }

    public void AssignTarget (Transform trgt)
    {
        myTarget = trgt;
    }
}
