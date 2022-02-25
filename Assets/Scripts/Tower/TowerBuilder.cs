using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale; 
    [SerializeField] private Beam _beam;
    [SerializeField] private StartPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionalScale = 0.5f;
    private int _levelPlayer;
    private int _platformLength;
    private Beam _beamInstantiate;
    private StartPlatform _startPlatformInstantiate;

    public Beam BeamInstantiate => _beamInstantiate;
    public StartPlatform SpawnPlatformInstantiate => _startPlatformInstantiate; 
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale + _additionalScale/2f;

    private void Awake()
    {
        Build(); 
    }

    private void GetLevelPlayer()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
        _levelPlayer = PlayerPrefs.GetInt("Level");
    }

    private void Build()
    {
        GetLevelPlayer();
        PlatformLength();

        _beamInstantiate = Instantiate(_beam, transform);
        _beamInstantiate.transform.localScale = new Vector3(1, BeamScaleY + _levelPlayer/2f, 1);

        Vector3 spawnPosition = _beamInstantiate.transform.position;
        spawnPosition.y += _beamInstantiate.transform.localScale.y - _additionalScale;
        SpawnPlatform(_spawnPlatform, ref spawnPosition, _beamInstantiate.transform);
        for (int i = 0; i< _levelCount + _levelPlayer; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platformLength)], ref spawnPosition, _beamInstantiate.transform); 
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, _beamInstantiate.transform);
    }

    private Platform SpawnPlatform(Platform platform, ref Vector3 spawnPosition,Transform parent)
    {
        Platform paltform = Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1f;
        return platform;
    }

    private void PlatformLength()
    {
        if (_levelPlayer < _platforms.Length)
            _platformLength = _levelPlayer;
        else
            _platformLength = _platforms.Length;
    }
}
