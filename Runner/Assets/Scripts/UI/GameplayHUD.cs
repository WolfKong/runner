using UnityEngine;
using UnityEngine.UI;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private Text targetScore;

    private void Start()
    {
        targetScore.text = $"Target: {gameplayData.LevelData.TargetScore}";
    }
}
