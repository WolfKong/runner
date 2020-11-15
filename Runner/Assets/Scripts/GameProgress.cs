using UnityEngine.SceneManagement;

public static class GameProgress
{
    public static LevelData CurrentLevel { get; set; }
    public static int CurrentScore { get; private set; }

    public static void IncrementScore()
    {
        CurrentScore++;

        if (CurrentScore >= CurrentLevel.TargetScore)
            SceneManager.LoadScene("LevelComplete");
    }

    public static void StartLevel()
    {
        CurrentScore = 0;
    }
}
