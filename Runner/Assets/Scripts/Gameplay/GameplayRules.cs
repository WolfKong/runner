using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayRules : MonoBehaviour
{
    [SerializeField] private FloatVariable playerScore;
    [SerializeField] private GameplayData gameplayData;

    private LevelData levelData;

    void Start()
    {
        playerScore.Value = 0;
        levelData = gameplayData.LevelData;
    }

    private void Update()
    {
        if (playerScore.Value >= levelData.TargetScore)
            SceneManager.LoadScene("LevelComplete");
    }
}
