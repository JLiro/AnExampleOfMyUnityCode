using UnityEngine;
using UnityEngine.Events;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _middlePlatform;
    [SerializeField] private FinishPlatform _finishPlatform;

    [SerializeField] private ColorPalette[] _colorPalette;

    private float _startAndFinishAdditionalScale = 0.5f;
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;

    private void Awake()
    {
        Build();
        ChangeColorsPalette();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, Quaternion.identity, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_middlePlatform[Random.Range(0, _middlePlatform.Length)], ref spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, Quaternion.identity, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Quaternion rotation, Transform parents)
    {
        Instantiate(platform, spawnPosition, rotation, parents);
        spawnPosition.y -= 1;
    }

    private void ChangeColorsPalette()
    {
        _colorPalette[Random.Range(0, _colorPalette.Length)].SetColorsForObjects();
    }
}
