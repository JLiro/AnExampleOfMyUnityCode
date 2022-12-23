using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "new ColorPalette", menuName = "Color Palette", order = 51)]
public class ColorPalette : ScriptableObject
{
    [SerializeField] private Color _scoreСounter;
    [SerializeField] private Color _sky;
    [SerializeField] private Color _beam;
    [SerializeField] private Color _ball;
    [SerializeField] private Color _safeSegment;
    [SerializeField] private Color _dangerousSegment;

    public void SetColorsForObjects()
    {
        FindObjectOfType<TMP_Text>().color = _scoreСounter;
        FindObjectOfType<Camera>().backgroundColor = _sky;
        FindObjectOfType<Beam>().GetComponent<Renderer>().material.color = _beam;
        FindObjectOfType<Ball>().GetComponent<Renderer>().material.color = _ball;

        if (FindObjectsOfType<SafePlatformSegment>() != null)
        {
            SafePlatformSegment[] safeSegments = FindObjectsOfType<SafePlatformSegment>();
            foreach (SafePlatformSegment segment in safeSegments) { segment.GetComponent<Renderer>().material.color = _safeSegment; }
        }

        if (FindObjectsOfType<DangerousPlatformSegment>() != null)
        {
            DangerousPlatformSegment[] dangerousSegments = FindObjectsOfType<DangerousPlatformSegment>();
            foreach (DangerousPlatformSegment segment in dangerousSegments) { segment.GetComponent<Renderer>().material.color = _dangerousSegment; }
        }
    }
}
