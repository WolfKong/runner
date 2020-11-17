using System.Collections.Generic;
using UnityEngine;

public class GameplayRules : MonoBehaviour
{
    [SerializeField] private FloatVariable playerScore;
    [SerializeField] private GameplayData gameplayData;

    private LevelData levelData;
    private bool gameOver;

    void Start()
    {
        gameOver = false;
        playerScore.Value = 0;
        levelData = gameplayData.LevelData;
    }

    private void Update()
    {
        if (!gameOver && playerScore.Value >= levelData.TargetScore)
        {
            gameOver = true;
            SceneLoader.LoadScene("LevelComplete");

            var postData = new Dictionary<string, string> { { levelData.name, playerScore.Value.ToString() } };
            ServiceLocator.Instance.Get<RestAPI>().Post("https://www.example.com", postData);
        }
    }
}
