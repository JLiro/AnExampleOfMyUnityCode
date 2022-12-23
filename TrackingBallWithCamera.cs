using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBallWithCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lehght;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimalBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minimalBallPosition = _ball.transform.position;
    }

    private void Update()
    {
        if(_ball.transform.position.y < _minimalBallPosition.y)
        {
            TrackBall();
            _minimalBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _lehght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
