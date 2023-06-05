using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuManager : MonoBehaviour
{
    #region UIFields.
    [SerializeField] private GameObject openMenuButton;
    [SerializeField] private GameObject loadGameButton;

    [SerializeField] private GameObject menuWindow;
    [SerializeField] private GameObject nicknameWindow;
    [SerializeField] private GameObject settingsWindow;

    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle effectsToggle;

    [SerializeField] private TMP_InputField nicknameInput;
    #endregion

    #region Audio fields.
    [SerializeField] private AudioClip mouseOverClip;
    #endregion

    #region Awake, Start, Update, LateUpdate, FixedUpdate.
    private void Start()
    {
        //TODO: Убрать в обработчик, как допишется game сцена.
        loadGameButton.GetComponent<EventTrigger>().enabled = false;
        if (DataManager.Instance.LoadPlayerData())
        {
            loadGameButton.GetComponent<Button>().interactable =
            loadGameButton.GetComponent<EventTrigger>().enabled = true;
        }

        if (DataManager.Instance.LoadSettingsData())
        {
            effectsToggle.isOn = DataManager.Instance.SettingsData.Effects;
            musicToggle.isOn = DataManager.Instance.SettingsData.Music;
        }
    }
    private void Update()
    {
        if (openMenuButton.activeSelf)
            if (Input.anyKeyDown)
                OpenMenu();
    }
    #endregion

    #region "Press any key" window.
    /// <summary>
    /// Обработчик события элемента управления Open Menu Button.
    /// Отключает элемент управления Open Menu Button и включает Menu Window.
    /// </summary>
    public void OpenMenu()
    {
        openMenuButton.SetActive(!openMenuButton.activeSelf);
        menuWindow.SetActive(!menuWindow.activeSelf);
    }
    #endregion

    #region Menu window.
    /// <summary>
    /// Обработчик события элемента управления New Game Button.
    /// Отключяет элемент управления Menu Window и включает Nickname Window.
    /// </summary>
    public void OpenNicknameWindow()
    {
        menuWindow.SetActive(!menuWindow.activeSelf);
        nicknameWindow.SetActive(!nicknameWindow.activeSelf);
    }

    //TODO: Добавить данные в PlayersData, для инициализации DataManager. Кнопка загрузить работает от присутствия файла сохранения.
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Обработчик события элемента управления Settings Button.
    /// Отключяет элемент управления Menu Window и включает Settings Window.
    /// </summary>
    public void OpenSettings()
    {
        menuWindow.SetActive(false);
        settingsWindow.SetActive(true);
    }

    /// <summary>
    /// Обработчик события элемента управления Exit Button.
    /// Выходит из игры.
    /// </summary>
    public void ExitGame()
    {
        //TODO: Возможно, понадобится закрытие в браузере.
        //TODO: Сохранение настроек реализовано при обработке события.
        //TODO: Сохранение данных игрока - реализовать в game сцене.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    #endregion

    #region Nickname window.
    /// <summary>
    /// Обаботчик события кнопки Back Button.
    /// Отключяет элемент управления Nickname WIndow и включает Menu Window.
    /// </summary>
    public void CloseNicknameWindow()
    {
        nicknameWindow.SetActive(!nicknameWindow.activeSelf);
        menuWindow.SetActive(!menuWindow.activeSelf);
    }

    /// <summary>
    /// Обработчик события элемента управления Confirm Button.
    /// Обновляет данные в DataManager(не сохраняет!) и запускает сцену game.
    /// </summary>
    public void PlayGame()
    {
        if (nicknameInput.text != string.Empty)
        {
            DataManager.Instance.PlayerData.PlayerName = nicknameInput.text;
            SceneManager.LoadScene(1);
        }
    }
    #endregion

    #region Settings window.
    /// <summary>
    /// Обработчик события элемента управления Close Settings Buttons.
    /// Отключяет элемент управления Settings Window и включает Menu Window.
    /// </summary>
    public void CloseSettings()
    {
        settingsWindow.SetActive(!settingsWindow.activeSelf);
        menuWindow.SetActive(!menuWindow.activeSelf);
    }

    /// <summary>
    /// Обработчик события элемента управления Music Toggle.
    /// </summary>
    /// <param name="toggleValue"> Музыка включена? true - да. </param>
    public void SwitchMusic(bool toggleValue)
    {
        switch (toggleValue)
        {
            case true:
                GetComponent<AudioSource>().Play();
                break;
            case false:
                GetComponent<AudioSource>().Stop(); // Yes, without pause.
                break;
        };
        DataManager.Instance.SettingsData.Music = toggleValue;
        musicToggle.OnDeselect(null);
        DataManager.Instance.SaveSettingsData();
    }

    /// <summary>
    /// Обработчик события Effects Toggle.
    /// </summary>
    /// <param name="toggleValue"> Эффекты включены? true - да. </param>
    public void SwitchEffects(bool toggleValue)
    {
        DataManager.Instance.SettingsData.Effects = toggleValue;
        effectsToggle.OnDeselect(null);
        DataManager.Instance.SaveSettingsData();
    }
    #endregion

    #region Other methods.
    /// <summary>
    /// Обработчик события элементов управления.
    /// Воспроизводит звуковую дорожку поверх основной музыки.
    /// </summary>
    public void PlaySound()
    {
        if(DataManager.Instance.SettingsData.Effects) // !From DataManager;
           GetComponent<AudioSource>().PlayOneShot(mouseOverClip);
    }
    #endregion
}
