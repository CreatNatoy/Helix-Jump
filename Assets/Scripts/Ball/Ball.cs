using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSigment platformSigment))
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out FinishPlatform finishPlatform))
        {
            AddLevel();
            SceneManager.LoadScene(1);
        }
    }

    private void AddLevel()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}
