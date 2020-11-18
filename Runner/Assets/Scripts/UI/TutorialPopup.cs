using UnityEngine;
using UnityEngine.UI;

public class TutorialPopup : MonoBehaviour
{
    [SerializeField] private Button okButton;
    [SerializeField] private Toggle toggle;

    private void Start()
    {
        okButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        PlayerPrefs.SetInt("TutorialComplete", toggle.isOn ? 1 : 0);
        Destroy(gameObject);
        Time.timeScale = 1;
    }
}
