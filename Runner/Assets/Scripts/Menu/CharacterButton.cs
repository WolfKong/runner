using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour, IDataUI
{
    [SerializeField] private GameplayData gameplayData;
    [SerializeField] private Image image;
    [SerializeField] private GameObject selectedImage;
    [SerializeField] private Text nameText;
    [SerializeField] private Button button;

    private CharacterData characterData;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetData(ScriptableObject data)
    {
        characterData = (CharacterData)data;
        image.color = characterData.Material.color;
        nameText.text = characterData.name;

        selectedImage.SetActive(gameplayData.CharacterData == characterData);
    }

    private void OnClick()
    {
        gameplayData.CharacterData = characterData;
        selectedImage.SetActive(true);
    }

    private void Update()
    {
        if (selectedImage.activeSelf && gameplayData.CharacterData != characterData)
            selectedImage.SetActive(false);
    }
}
