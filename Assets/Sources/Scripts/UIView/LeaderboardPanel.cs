using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel : UIPanel
{
    [SerializeField] private Button _backButton;

    private void OnEnable()
    {
        //SetAudioService();
        AddButtonListener(_backButton, OnClickBack);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveAllListeners();
    }

    private void OnClickBack()
    {
        Hide();
    }
}