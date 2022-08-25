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
        int index = SceneManager.GetActiveScene().buildIndex;
        _levelNumber.text = "Level " + index++.ToString();
    }
}
