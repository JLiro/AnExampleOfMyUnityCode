using UnityEngine;
using UnityEngine.Events;


public class Ball : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    private void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TriggerPlatformSegment triggerSegment))
        {
            Destroy(triggerSegment);
            IncreaseScore();
        }

        if (other.TryGetComponent(out PlatformSegment platformSegments))
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DangerousPlatformSegment dangerousSegment))
        {
            Debug.Log("Danger!");
        }
    }
}
