using System.Collections.Generic;
using UnityEngine;

public class LevelList : MonoBehaviour
{
    [SerializeField] private LevelButton buttonPrefab;

    private List<LevelData> levelDatas;

    private void Awake()
    {
        var levels = Resources.LoadAll("", typeof(LevelData));

        levelDatas = new List<LevelData>();
        foreach (var level in levels)
            levelDatas.Add((LevelData)level);
    }

    void Start()
    {
        foreach (var levelData in levelDatas)
        {
            var button = Instantiate<LevelButton>(buttonPrefab, transform);
            // button.Button.onClick.AddListener(() => OnClick(levelData));
            button.SetData(levelData);
        }
    }

    // private void OnClick(LevelData data)
    // {
    //     levelView.SetLevel(data);

    //     gameObject.SetActive(false);
    // }
}
