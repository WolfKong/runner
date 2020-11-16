using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IDataUI
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private Image image;
    [SerializeField] private Text nameText;
    [SerializeField] private Text targetScore;
    [SerializeField] private Button button;

    private LevelData levelData;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetData(ScriptableObject data)
    {
        levelData = (LevelData)data;
        image.sprite = levelData.MenuImage;
        nameText.text = levelData.name;
        targetScore.text = $"Target: {levelData.TargetScore}";
    }

    private void OnClick()
    {
        gameplayData.LevelData = levelData;
        SceneLoader.LoadScene("Gameplay");
    }
}
