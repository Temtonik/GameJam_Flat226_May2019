using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    List<VoodooDoll> voodooDolls;

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
