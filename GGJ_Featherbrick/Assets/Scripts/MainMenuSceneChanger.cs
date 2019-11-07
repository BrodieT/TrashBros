using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuSceneChanger : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject MusicOnOffButton;
    public GameObject SoundOnOffButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GLOBAL_.MusicEnabled)
        {
            MusicOnOffButton.GetComponentInChildren<Text>().text = "Is On";
        }
        else
        {
            MusicOnOffButton.GetComponentInChildren<Text>().text = "Is Off";
        }

        if (GLOBAL_.SoundEnabled)
        {

            SoundOnOffButton.GetComponentInChildren<Text>().text = "Is On";
        }
        else
        {
            SoundOnOffButton.GetComponentInChildren<Text>().text = "Is Off";
        }
    }

    public void MusicToggle()
    {
        GLOBAL_.MusicEnabled = !GLOBAL_.MusicEnabled;
        Debug.Log("Music toggle");
     
    }


    public void SoundToggle()
    {
        GLOBAL_.SoundEnabled = !GLOBAL_.SoundEnabled;
        Debug.Log("Sound toggle");

    }
     void Exit()
    {
        Application.Quit();
    }

    void GoToPlayerSelect()
    {
        SceneManager.LoadScene("Assets/Scenes/Menu Player Select.unity", LoadSceneMode.Single);
    }
}
