using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerManager : MonoBehaviour
{
    private List<VoodooDoll> voodooDolls = new List<VoodooDoll>();

    public static PlayerManager s_Singleton;

    public float jumpHigher = 0, fly = 0;
    public bool doubleJump = false;


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

    private void Start()
    {
        if (PlayerPrefs.HasKey(SaveGame.X_POSITION))
        {
            Vector2 savedPos = new Vector2(PlayerPrefs.GetFloat(SaveGame.X_POSITION), PlayerPrefs.GetFloat(SaveGame.Y_POSITION));
            transform.position = savedPos;
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
        if(jumpHigher != 0)
            gameObject.GetComponent<PlatformerCharacter2D>().SetJumpForce(jumpHigher);
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
