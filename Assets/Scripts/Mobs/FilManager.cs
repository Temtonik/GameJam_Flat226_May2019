using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilManager : MonoBehaviour
{
    private Vector3 opos, oscale, oSize;

    private void Awake()
    {
        opos = transform.position;
        oscale = transform.localScale;
        oSize = transform.lossyScale;
    }

    public void FollowSpider(Transform spider, Vector3 origin, float speed)
    {
        transform.position = new Vector3(transform.position.x,opos.y + (oSize.y - transform.lossyScale.y), transform.position.z);
        transform.localScale = new Vector3(oscale.x, oscale.y + (origin.y - spider.position.y), 1);
    }
}
