using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private FloatVariable playerScore;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button retryButton;

    void Start()
    {
        scoreText.text = $"Score: {playerScore.Value}";
        menuButton.onClick.AddListener(GoToMenu);
        retryButton.onClick.AddListener(RetryLevel);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void RetryLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
