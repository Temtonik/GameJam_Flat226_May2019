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

    public float respawnCD = 1.2f;
    private Vector3 spawnPoint;
    private SpriteRenderer mySprite;
    public GameObject vfxDeath;
    private Animator myAnim;
    public Transform soulsParent;
    public GameObject willO;
    private List<SoulSpot> soulsSpots = new List<SoulSpot>();
    private AudioSource myAS;
    public AudioClip transfoSFX;
    public AudioClip looseSoulSFX;
    private List<GameObject> willOs = new List<GameObject>();

    private bool canplay = true;

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
        mySprite = GetComponent<SpriteRenderer>();
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
        spawnPoint = transform.position;
    }

    public void FreezeCharacter ()
    {
        canplay = false;
        GetComponent<PlatformerCharacter2D>().Freeze();
    }

    public void UnfreezeCharacter()
    {
        canplay = true;
        GetComponent<PlatformerCharacter2D>().Unfreeze();
    }

    private void Update()
    {
        if (!canplay)
            return;

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

        GetComponent<PlatformerCharacter2D>().doubleJumpAllow = doubleJump;
        if (jumpHigher != 0)
            GetComponent<PlatformerCharacter2D>().SetJumpForce(jumpHigher);
        GetComponent<PlatformerCharacter2D>().flyAllow = fly;
        GetComponent<PlatformerCharacter2D>().time = time;
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
        mySprite.enabled = false;
        Destroy(Instantiate(vfxDeath, transform.position, Quaternion.identity), 0.8f);
        StartCoroutine("RespawnCD");
    }

    IEnumerator RespawnCD ()
    {
        yield return new WaitForSeconds(respawnCD);
        Respawn();
    }

    private void Respawn ()
    {
        transform.position = spawnPoint;
        mySprite.enabled = true;
    }

    public void UpdateSpawnPoint ()
    {
        spawnPoint = transform.position;
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

    public void EarnASoul (VoodooDoll aDoll)
    {
        voodooDolls.Remove(aDoll);
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
}
