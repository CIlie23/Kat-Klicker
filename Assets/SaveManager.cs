using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {

    public static SaveManager instance { get; private set; }

    [Header("Main Game Loop")]
    public int count; 
    public int currentCat;//update this every time you wanna save something
    public bool[] catsUnlocked = new bool[3] { false, false, false };//adjust this every time you add a new cat

    [Header("Music Volume")]
    [SerializeField]
    private Slider volSlider = null;


    // Use this for initialization
    private void Start()
    {
        LoadVolumeValues();
    }

    public void Awake()
    {
        if(instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        LoadVolumeValues();
        Load();
     }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/LeNEWSaveFile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/LeNEWSaveFile.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            count = data.count;//update this every time you wanna save something
            currentCat = data.currentCat;
            catsUnlocked = data.catsUnlocked;

            if (data.catsUnlocked == null)
                catsUnlocked = new bool[3] { false, false, false };

            LoadVolumeValues();
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/LeNEWSaveFile.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.count = count;//update this every time you wanna save something
        data.currentCat = currentCat;
        data.catsUnlocked = catsUnlocked;


        bf.Serialize(file, data);
        file.Close();
    }

    public void SaveVolumeButtom()
    {
        float volumeValue = volSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadVolumeValues();
        Debug.Log("Volume has been saved");
    }

    void LoadVolumeValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}

[Serializable]
class PlayerData_Storage
{
    public int count;
    public int currentCat;//update this every time you wanna save something
    public bool[] catsUnlocked;
}


//The only problem I have right now with this, is that it won't load it the moment i start the game, but that's ok-ish for now
//NVM! Ignore the thing said above, I just had to update the value in void Update()
//Full credit to this guy : https://www.youtube.com/watch?v=UZ7g8EyG6J0
//Couldn't figure it out without him

//Music settings slightly inspider by this guy
// https://www.youtube.com/watch?v=k2vOeTK0z2g