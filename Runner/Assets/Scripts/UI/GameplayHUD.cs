using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private Text targetScore;
    [SerializeField] private GameObject tutorialPopup;

    private void Start()
    {
        targetScore.text = $"Target: {gameplayData.LevelData.TargetScore}";

        if (PlayerPrefs.GetInt("TutorialComplete") == 0)
            StartCoroutine(ShowTutorial());
    }

    private IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(0.6f);

        Instantiate(tutorialPopup, transform.parent);
        Time.timeScale = 0;
    }
}
