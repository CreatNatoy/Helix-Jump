using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f; 
    }

    public void ButtonPause(GameObject Panel)
    {
        Panel.SetActive(true); 
        Time.timeScale = 0f; 
    }

    public void ButtonPlay(GameObject Panel)
    {
        Panel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void ButtonExit()
    {
        Application.Quit(); 
    }

    public void ButtonDeletKey()
    {
        PlayerPrefs.DeleteKey("Level"); 
    }
}
