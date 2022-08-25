using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private SceneReference _sceneReference;
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {

    }
}
