using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private ParticleSystem _particleSystemBlow;
    [SerializeField] private Camera _camera;

    private Music _musicEffectJump; 
    private Rigidbody _rigidbody;
    private bool _readyJump;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
       _particleSystemBlow = Instantiate(_particleSystemBlow);
        _camera = FindObjectOfType<Camera>(); 
        _musicEffectJump = _camera.gameObject.GetComponent<Music>();

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSigment platformSegment))
        {
            _readyJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSigment platformSegment) && !_readyJump)
        {
            _musicEffectJump.PlayJumpSound(); 
            JumpeBall();
            ParticleSystemBlow(collision);
        }
    }



    private void JumpeBall()
    {
        _readyJump = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void ParticleSystemBlow(Collision collision)
    {
        Vector3 position = collision.contacts[0].point; 
        _particleSystemBlow.transform.position = position;
        _particleSystemBlow.Play(); 
    }

}
