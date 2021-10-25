using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallDie : MonoBehaviour
{
    private PanelGameOver _panelGameOver;

    private void Start()
    {
        _panelGameOver = FindObjectOfType<PanelGameOver>(); 
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out DiePlatform diePlatform))
        {
            _panelGameOver.SetActivePanelGameOver(); 
          //  SceneManager.LoadScene(1);
        }
    }
}
