using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpot : MonoBehaviour
{

    private bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsOccupied ()
    {
        return isOccupied;
    }

    public void SetOccupied ()
    {
        isOccupied = true;
    }

    public void SetUnoccupied()
    {
        isOccupied = false;
    }
}

