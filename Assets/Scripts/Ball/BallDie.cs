using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallDie : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out DiePlatform diePlatform))
        {           
            SceneManager.LoadScene(0);
        }
    }
}
