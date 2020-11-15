using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayRules : MonoBehaviour
{
    [SerializeField] private FloatVariable playerScore;

    private LevelData levelData;

    void Start()
    {
        playerScore.Value = 0;
        levelData = GameProgress.CurrentLevel;
    }

    private void Update()
    {
        if (playerScore.Value >= levelData.TargetScore)
            SceneManager.LoadScene("LevelComplete");
    }
}
