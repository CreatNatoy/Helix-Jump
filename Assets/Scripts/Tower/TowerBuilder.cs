using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale; 
    [SerializeField] private GameObject _beam;
    [SerializeField] private StartPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionalScale = 0.5f;
    private int _levelPlayer;
    private int _platformLength; 

    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale/2f;

    private void Awake()
    {
        Build(); 
    }

    private void Start()
    {

    }

    private void LevelPlayer()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
        _levelPlayer = PlayerPrefs.GetInt("Level");
    }

    private void Build()
    {
        LevelPlayer();
        PlatformLength();

        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY + _levelPlayer/2f, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform); 

        for(int i = 0; i< _levelCount + _levelPlayer; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platformLength)], ref spawnPosition, beam.transform); 
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition,Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1f; 
    }

    private void PlatformLength()
    {
        if (_levelPlayer < _platform.Length)
            _platformLength = _levelPlayer;
        else
            _platformLength = _platform.Length;
    }
}
