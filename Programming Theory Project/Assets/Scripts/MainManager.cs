using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public string _playerName;
    public bool isDog;
    public bool isCat;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    [System.Serializable]
    class Savedata
    {
        public string _playerName;
        public bool isDog;
        public bool isCat;
    }

    public void SaveData()
    {
        Savedata data = new Savedata();
        data._playerName = _playerName;
        data.isDog = isDog;
        data.isCat = isCat;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.Json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.Json");
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.Json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Savedata data = JsonUtility.FromJson<Savedata>(json);

            _playerName = data._playerName;
            isDog = data.isDog;
            isCat = data.isCat;
        }

        
    }
}
