using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : CanvasWindow
{
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(OnNextLevelButtonClicked);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(OnNextLevelButtonClicked);
    }

    public override void OnShown()
    {
        _animator.SetTrigger("Show");
    }

    public void OnNextLevelButtonClicked()
    {
        Singleton<LevelLoader>.Instance.LoadNextLevel();
    }
}
