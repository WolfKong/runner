using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text nameText;
    [SerializeField] private Button button;

    private LevelData levelData;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetData(LevelData data)
    {
        levelData = data;
        image.sprite = data.MenuImage;
        nameText.text = data.name;
    }

    private void OnClick()
    {
        GameProgress.CurrentLevel = levelData;
        SceneManager.LoadScene("Gameplay");
    }
}
