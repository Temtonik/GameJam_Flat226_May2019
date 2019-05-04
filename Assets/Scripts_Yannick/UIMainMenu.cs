using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void OnClickPlay ()
    {
        if (PlayerPrefs.HasKey(SaveGame.X_POSITION))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
