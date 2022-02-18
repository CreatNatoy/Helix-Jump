using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;
    [SerializeField] private TowerBuilder _towerBuilder; 

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition; 

    private void Start()
    {
        _ball = Ball.Instance;
        _beam = _towerBuilder.BeamInstantiate;

        if (_ball == null)
            Debug.Log("Ball Empty");
        if (_beam == null)
            Debug.Log("Beam Empty"); 

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        TrackBall(); 
    }

    private void Update()
    {
        if(_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position; 
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform); 
    }

}
