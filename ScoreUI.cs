using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreView;
    
    private Ball _ball;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _ball.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _ball.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreView.text = score.ToString();
    }
}
