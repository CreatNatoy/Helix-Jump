using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private float _playTime = 1f;
    private float _stopTime = 0f; 

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
        TimeGame(_playTime);
    }

    public void ButtonPause(GameObject Panel)
    {
        Panel.SetActive(true);
        TimeGame(_stopTime);
    }

    public void ButtonPlay(GameObject Panel)
    {
        Panel.SetActive(false);
        TimeGame(_playTime);
    }

    private void TimeGame(float time)
    {
        Time.timeScale = time;
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
