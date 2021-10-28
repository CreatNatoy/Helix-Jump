using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpSound; 

    public void PlayJumpSound()
    {
        _audioSource.PlayOneShot(_jumpSound); 
    }

}
