using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _optionButton;
    [SerializeField] private Button _ExitButton;

    [SerializeField] private GameObject _optionPanel;
    [SerializeField] private Button _optionPanelExitButton;

    private void Awake()
    {
        OnClickOptionPanelExitButton();
        _startButton.onClick.AddListener(OnClickStartButton);
        _optionButton.onClick.AddListener(OnClickOptionButton);
        _ExitButton.onClick.AddListener(OnClickExitButton);
        _optionPanelExitButton.onClick.AddListener(OnClickOptionPanelExitButton);
    }
    private void OnClickOptionPanelExitButton()
    {
        _optionPanel.SetActive(false);
    }
    private static void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnClickOptionButton()
    {
        _optionPanel.SetActive(true);
    }

    private static void OnClickExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}