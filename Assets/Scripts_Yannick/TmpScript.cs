using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TmpScript : MonoBehaviour
{
    public Text skipText;
    public GameObject skipImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SkipIntro"))
        {
            LoadGame();
        }
    }

    public void LoadGame ()
    {
        skipImage.SetActive(false);
        skipText.text = "CHARGEMENT...";
        SceneManager.LoadScene(2);
    }
}
