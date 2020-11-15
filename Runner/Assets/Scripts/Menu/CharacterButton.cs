using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private Image image;
    [SerializeField] private Text nameText;
    [SerializeField] private Button button;

    private CharacterData characterData;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetData(CharacterData data)
    {
        characterData = data;
        image.color = data.Material.color;
        nameText.text = data.name;
    }

    private void OnClick()
    {
        gameplayData.CharacterData = characterData;
    }
}
