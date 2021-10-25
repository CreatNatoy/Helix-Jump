using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGameOver : MonoBehaviour
{
    [SerializeField] private GameObject _panelGameOver; 

    public void SetActivePanelGameOver()
    {
        _panelGameOver.SetActive(true);
        Time.timeScale = 0f; 
    }
}
