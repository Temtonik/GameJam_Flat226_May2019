using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<VoodooDoll> voodooDolls = new List<VoodooDoll>();

    public static PlayerManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            AbsorbVoodooDoll(true);
        } else if (Input.GetKeyUp(KeyCode.Joystick1Button1))
        {
            AbsorbVoodooDoll(false);
        }
    }

    public void AddVoodooDoll(VoodooDoll doll)
    {
        voodooDolls.Add(doll);
    }

    void AbsorbVoodooDoll(bool absorbing)
    {
        foreach(VoodooDoll doll in voodooDolls)
        {
            if (absorbing)
                doll.isAbsorbed = true;
            else
                doll.isAbsorbed = false;
        }
    }
}
