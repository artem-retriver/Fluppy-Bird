using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesVolumeDifficults : MonoBehaviour
{
    private GameManager gameManager;
    private VolumeValue volumeValue;

    public float saveVolume;
    public int saveDifficult;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        volumeValue = FindObjectOfType<VolumeValue>();

        if (PlayerPrefs.HasKey("Volume"))
        {
            saveVolume = PlayerPrefs.GetFloat("Volume");
            volumeValue.musicVolume = saveVolume;
        }

        if (PlayerPrefs.HasKey("Difficult"))
        {
            saveDifficult = PlayerPrefs.GetInt("Difficult");
            gameManager.chooseDifficult = saveDifficult;
        }
    }

    private void Update()
    {
        saveVolume = volumeValue.musicVolume;
        saveDifficult = gameManager.chooseDifficult;

        PlayerPrefs.SetFloat("Volume", saveVolume);
        PlayerPrefs.SetInt("Difficult", saveDifficult);
    }
}
