using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private GameObject _splashEffect;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private bool _ignoreNextCollision;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegments) && _ignoreNextCollision == false)
        {
            SplashEffect(collision);
            
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            _ignoreNextCollision = true;
            Invoke("AllowCollision", .2f);
        }
    }

    private void AllowCollision()
    {
        _ignoreNextCollision = false;
    }

    private void SplashEffect(Collision collision)
    {
        Instantiate(_splashEffect, new Vector3(transform.position.x, collision.transform.position.y + 0.24f, transform.position.z), Quaternion.Euler(90, 0, 0));
    }
}