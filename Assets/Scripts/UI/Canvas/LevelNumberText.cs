using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNumberText : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumber;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Won += OnLevelChanged;

        OnLevelChanged();
    }

    private void OnDisable()
    {
        _player.Won -= OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        _levelNumber.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
