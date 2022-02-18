using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
     private GameObject _panelNextLevel;

    public static Ball Instance { get; private set; }

    private void Awake()
    {
            if (Instance == null)
                Instance = this; 
    }

    private void Start()
    {
        _panelNextLevel = GameObject.FindGameObjectWithTag("PanelNextLevel");
        _panelNextLevel.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSigment platformSigment))
        {
            other.GetComponentInParent<Platform>().Break();
        }
        if (other.TryGetComponent(out FinishPlatform finishPlatform))
        {
            PanelNextLevel();
        }
    }

    private void PanelNextLevel()
    {
        _panelNextLevel.SetActive(true); 
        AddLevel();
    }

    private void AddLevel()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}
