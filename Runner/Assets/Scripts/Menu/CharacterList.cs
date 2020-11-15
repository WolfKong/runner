using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    [SerializeField] private CharacterButton buttonPrefab;

    private List<CharacterData> characterDatas;

    private void Awake()
    {
        var runners = Resources.LoadAll("Data/Runners", typeof(CharacterData));

        characterDatas = new List<CharacterData>();
        foreach (var runner in runners)
            characterDatas.Add((CharacterData)runner);
    }

    void Start()
    {
        foreach (var data in characterDatas)
        {
            var button = Instantiate<CharacterButton>(buttonPrefab, transform);
            button.SetData(data);
        }
    }
}
