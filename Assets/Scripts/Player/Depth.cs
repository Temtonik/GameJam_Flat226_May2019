using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    public int orderInLayer;
    public int zPosition;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<SpriteRenderer>())
            {
                child.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
                child.transform.position = new Vector3(child.transform.position.x, child.transform.position.y, -zPosition);
            }
        }
    }
}
