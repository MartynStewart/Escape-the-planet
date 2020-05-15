using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum menuState {Main, Options, Credits, Instructions}

public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject OptionPanel;
    [SerializeField] GameObject CreditPanel;
    [SerializeField] GameObject InstructionsPanel;
    [SerializeField] GameObject StartGameButton;
    [SerializeField] Slider volumeSlider;
    AudioManager audioManager = AudioManager.GetInstance();
    menuState currentMenu = menuState.Main;

    void Start() {
        MainMenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
        CreditPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        StartGameButton.SetActive(false);
    }

    public void StartClick() {
        MainMenuPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
        currentMenu = menuState.Instructions;
        Invoke("ShowGameStart", 2f);
    }

    public void OptionClick() {
        MainMenuPanel.SetActive(false);
        OptionPanel.SetActive(true);
        currentMenu = menuState.Options;
        GetOptions();
    }

    public void OptionApplyClick() {
        SetOptions();
        MainMenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
        currentMenu = menuState.Options;
    }

    public void OptionCancelClick() {
        MainMenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
        currentMenu = menuState.Options;
    }

    public void CreditClick() {
        MainMenuPanel.SetActive(false);
        CreditPanel.SetActive(true);
        currentMenu = menuState.Credits;
    }

    public void CreditMenu() {
        MainMenuPanel.SetActive(true);
        CreditPanel.SetActive(false);
        currentMenu = menuState.Main;
    }

    public void QuitClick() {
        Debug.Log("Quit");
        Application.Quit();
    }

    private void ShowGameStart() {
        StartGameButton.SetActive(true);
    }

    public void LoadGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SetOptions() {
        audioManager.SetVolume(volumeSlider.value);
    }

    private void GetOptions() {
        volumeSlider.value = audioManager.GetVolume();
    }

}
