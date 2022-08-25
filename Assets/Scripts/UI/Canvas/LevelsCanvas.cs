using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsCanvas : MonoBehaviour
{
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
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {

        }
    }
}
