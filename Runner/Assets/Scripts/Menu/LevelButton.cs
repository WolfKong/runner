using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text nameText;
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetData(LevelData data)
    {
        image.sprite = data.MenuImage;
        nameText.text = data.name;
    }

    private void OnClick()
    {
        Debug.LogWarning($"PV-CLIckei no {name}");
    }
}
