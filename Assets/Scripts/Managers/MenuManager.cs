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
        //TODO: ������ � ����������, ��� ��������� game �����.
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
    /// ���������� ������� �������� ���������� Open Menu Button.
    /// ��������� ������� ���������� Open Menu Button � �������� Menu Window.
    /// </summary>
    public void OpenMenu()
    {
        openMenuButton.SetActive(!openMenuButton.activeSelf);
        menuWindow.SetActive(!menuWindow.activeSelf);
    }
    #endregion

    #region Menu window.
    /// <summary>
    /// ���������� ������� �������� ���������� New Game Button.
    /// ��������� ������� ���������� Menu Window � �������� Nickname Window.
    /// </summary>
    public void OpenNicknameWindow()
    {
        menuWindow.SetActive(!menuWindow.activeSelf);
        nicknameWindow.SetActive(!nicknameWindow.activeSelf);
    }

    //TODO: �������� ������ � PlayersData, ��� ������������� DataManager. ������ ��������� �������� �� ����������� ����� ����������.
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// ���������� ������� �������� ���������� Settings Button.
    /// ��������� ������� ���������� Menu Window � �������� Settings Window.
    /// </summary>
    public void OpenSettings()
    {
        menuWindow.SetActive(false);
        settingsWindow.SetActive(true);
    }

    /// <summary>
    /// ���������� ������� �������� ���������� Exit Button.
    /// ������� �� ����.
    /// </summary>
    public void ExitGame()
    {
        //TODO: ��������, ����������� �������� � ��������.
        //TODO: ���������� �������� ����������� ��� ��������� �������.
        //TODO: ���������� ������ ������ - ����������� � game �����.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    #endregion

    #region Nickname window.
    /// <summary>
    /// ��������� ������� ������ Back Button.
    /// ��������� ������� ���������� Nickname WIndow � �������� Menu Window.
    /// </summary>
    public void CloseNicknameWindow()
    {
        nicknameWindow.SetActive(!nicknameWindow.activeSelf);
        menuWindow.SetActive(!menuWindow.activeSelf);
    }

    /// <summary>
    /// ���������� ������� �������� ���������� Confirm Button.
    /// ��������� ������ � DataManager(�� ���������!) � ��������� ����� game.
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
    /// ���������� ������� �������� ���������� Close Settings Buttons.
    /// ��������� ������� ���������� Settings Window � �������� Menu Window.
    /// </summary>
    public void CloseSettings()
    {
        settingsWindow.SetActive(!settingsWindow.activeSelf);
        menuWindow.SetActive(!menuWindow.activeSelf);
    }

    /// <summary>
    /// ���������� ������� �������� ���������� Music Toggle.
    /// </summary>
    /// <param name="toggleValue"> ������ ��������? true - ��. </param>
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
    /// ���������� ������� Effects Toggle.
    /// </summary>
    /// <param name="toggleValue"> ������� ��������? true - ��. </param>
    public void SwitchEffects(bool toggleValue)
    {
        DataManager.Instance.SettingsData.Effects = toggleValue;
        effectsToggle.OnDeselect(null);
        DataManager.Instance.SaveSettingsData();
    }
    #endregion

    #region Other methods.
    /// <summary>
    /// ���������� ������� ��������� ����������.
    /// ������������� �������� ������� ������ �������� ������.
    /// </summary>
    public void PlaySound()
    {
        if(DataManager.Instance.SettingsData.Effects) // !From DataManager;
           GetComponent<AudioSource>().PlayOneShot(mouseOverClip);
    }
    #endregion
}
