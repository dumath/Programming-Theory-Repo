using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    #region Acess.
    public static DataManager Instance { get; private set; }
    #endregion

    #region Data.
    public PlayerData PlayerData { get; private set; } = new PlayerData();
    public SettingsData SettingsData { get; private set; } = new SettingsData() { Music = true, Effects = true };
    #endregion

    #region Awake, Start, Update, LateUpdate, FixedUpdate.
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    #region Save/Load.
    /// <summary>
    /// Метод загрузки данных игрока.
    /// </summary>
    /// <returns> Данные игрока имеются? true - да. </returns>
    public bool LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/saved_player.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData = JsonUtility.FromJson<PlayerData>(json);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Метод сохранения данных игрока.
    /// </summary>
    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(PlayerData);
        File.WriteAllText(Application.persistentDataPath + "/saved_player.json", json);
    }

    /// <summary>
    /// Метод загрузки настроек пользователя.
    /// </summary>
    /// <returns> Настройки пользователя имеются? true - да. </returns>
    public bool LoadSettingsData()
    {
        string path = Application.persistentDataPath + "/saved_settings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData = JsonUtility.FromJson<SettingsData>(json);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Метод сохранения настроек пользователя.
    /// </summary>
    public void SaveSettingsData()
    {
        string json = JsonUtility.ToJson(SettingsData);
        File.WriteAllText(Application.persistentDataPath + "/saved_settings.json", json);
    }
    #endregion
}
