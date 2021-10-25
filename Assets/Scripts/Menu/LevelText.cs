using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    [SerializeField] private Text _textLevel;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
            PlayerPrefs.SetInt("Level", 1);
        _textLevel.text = $"Level: {PlayerPrefs.GetInt("Level")}";
    }
}
