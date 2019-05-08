using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private Animator myAnim;
    private bool ancestorsShown = false;
    private Gem currentGemScript;
    public Transform ancestorsParent;
    private int ancestorsNb = 0;

    public GameObject dialogueSection;
    public Text dialogueText;

    public static UIManager s_Singleton;

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

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            TogglePauseMenu();
        }
        else if (Input.GetAxis("AncestorsToggle") > 0.5f)
        {
            if (!ancestorsShown)
            {
                ShowAncestorsPortrait();
            }
        }
        else if (Input.GetAxis("AncestorsToggle") < 0.5f)
        {
            if (ancestorsShown)
            {
                HideAncestorsPortrait();
            }
        }

        if (dialogueSection.activeSelf && Input.GetButtonDown("Attack"))
        {
            HideDialogueBox();
        }
    }

    public void DisplayDialogueBox (string textToDisplay, Gem cGemScript)
    {
        currentGemScript = cGemScript;
        dialogueText.text = textToDisplay;
        PlayerManager.s_Singleton.FreezeCharacter();
        myAnim.SetTrigger("DialogueToggle");
    }

    public void HideDialogueBox()
    {
        currentGemScript.ActivateCollider();
        myAnim.SetTrigger("DialogueToggle");
        dialogueText.text = "";
    }

    public void FreeCharacter ()
    {
        PlayerManager.s_Singleton.UnfreezeCharacter();
    }

    public void LockCharacter()
    {
        PlayerManager.s_Singleton.FreezeCharacter();
    }

    public void AddAHead ()
    {
        ancestorsParent.GetChild(ancestorsNb).GetComponent<AncestorManager>().CompleteHead();
        ancestorsNb++;
    }

    public void ShowAncestorsPortrait()
    {
        ancestorsShown = true;
        myAnim.SetTrigger("ShowAncestors");
        myAnim.ResetTrigger("HideAncestors");
    }

    public void HideAncestorsPortrait()
    {
        ancestorsShown = false;
        myAnim.SetTrigger("HideAncestors");
    }

    public void TogglePauseMenu ()
    {
        myAnim.SetTrigger("TogglePause");
    }

    public void SetTimeScale (float timeScaleValue)
    {
        Time.timeScale = timeScaleValue;
    }

    public void ResetTriggers ()
    {
        myAnim.ResetTrigger("ShowAncestors");
        myAnim.ResetTrigger("TogglePause");
    }

    public void OnClickMainMenu ()
    {
        SceneManager.LoadScene(0);
    }
}
