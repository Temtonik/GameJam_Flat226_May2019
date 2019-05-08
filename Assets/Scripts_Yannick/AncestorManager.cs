using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestorManager : MonoBehaviour
{

    public GameObject headToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteHead ()
    {
        headToDisplay.SetActive(true);
    }
}
