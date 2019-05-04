using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private Animator myAnim;
    private bool ancestorsShown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);
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
    }

    public void ShowAncestorsPortrait()
    {
        ancestorsShown = true;
        myAnim.SetTrigger("ShowAncestors");
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
