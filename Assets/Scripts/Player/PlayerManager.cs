using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerManager : MonoBehaviour
{
    private List<VoodooDoll> voodooDolls = new List<VoodooDoll>();

    public static PlayerManager s_Singleton;

    public float jumpHigher = 0, time = 2;
    public bool doubleJump = false, fly = false;
    private int soulsAmount = 0;

    private Animator myAnim;
    public Transform soulsParent;
    public GameObject willO;
    private List<SoulSpot> soulsSpots = new List<SoulSpot>();
    private AudioSource myAS;
    public AudioClip transfoSFX;
    public AudioClip looseSoulSFX;
    private List<GameObject> willOs = new List<GameObject>();

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
        myAS = GetComponent<AudioSource>();
        foreach (Transform trs in soulsParent)
        {
            soulsSpots.Add(trs.GetComponent<SoulSpot>());
        }
        myAnim = GetComponent<Animator>();
        if (PlayerPrefs.HasKey(SaveGame.X_POSITION))
        {
            Vector2 savedPos = new Vector2(PlayerPrefs.GetFloat(SaveGame.X_POSITION), PlayerPrefs.GetFloat(SaveGame.Y_POSITION));
            transform.position = savedPos;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Absorb"))
        {
            myAnim.SetBool("Absorb", true);
            myAnim.SetBool("StartAbsorb", true);
            AbsorbVoodooDoll(true);
        }
        else if (!Input.GetButton("Absorb") && myAnim.GetBool("Absorb"))
        {
            myAnim.SetBool("Absorb", false);
            AbsorbVoodooDoll(false);
        }

        gameObject.GetComponent<PlatformerCharacter2D>().doubleJumpAllow = doubleJump;
        if (jumpHigher != 0)
            gameObject.GetComponent<PlatformerCharacter2D>().SetJumpForce(jumpHigher);
        gameObject.GetComponent<PlatformerCharacter2D>().flyAllow = fly;
        gameObject.GetComponent<PlatformerCharacter2D>().time = time;


    }

    public void Hit ()
    {
        if (soulsAmount > 0)
        {
            LooseASoul();
        }
        else if (soulsAmount == 0)
        {
            Death();
        }
    }

    private void Death ()
    {

    }

    public void LooseASoul ()
    {
        soulsAmount--;
        for (int i = 0; i < soulsParent.childCount; i++)
        {
            if (soulsSpots[i].IsOccupied())
            {
                soulsSpots[i].SetUnoccupied();
                Destroy(willOs[i]);
                break;
            }
        }
        myAnim.SetTrigger("Hit");
        myAS.clip = looseSoulSFX;
        myAS.Play();
    }

    public void EarnASoul ()
    {
        soulsAmount++;
        Transform tmpWill = null;
        
        foreach (SoulSpot sSpot in soulsSpots)
        {
            if (!sSpot.IsOccupied())
            {
                tmpWill = sSpot.transform;
                break;
            }
        }

        if (tmpWill != null)
        {
            GameObject will = Instantiate(willO, tmpWill.position, Quaternion.identity);
            will.GetComponent<WillO>().AssignTarget(tmpWill);
            tmpWill.GetComponent<SoulSpot>().SetOccupied();
            willOs.Add(will);
        }
        
    }

    public void PlayTransfoSFX()
    {
        myAS.clip = transfoSFX;
        myAS.Play();
    }

    public void AddVoodooDoll(VoodooDoll doll)
    {
        voodooDolls.Add(doll);
        PlayTransfoSFX();
    }

    void AbsorbVoodooDoll(bool absorbing)
    {
        foreach(VoodooDoll doll in voodooDolls)
        {
            if (absorbing)
                doll.StartAbsorbtion();
            else
                doll.StopAbsorbtion();
        }
    }

    public void OnDollAbsorbed (VoodooDoll aDoll)
    {
        voodooDolls.Remove(aDoll);
        EarnASoul();
    }
}
