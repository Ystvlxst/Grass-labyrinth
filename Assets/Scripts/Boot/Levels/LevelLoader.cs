using UnityEngine;

public class LevelLoader : Singleton<LevelLoader>
{
    private const string SavedLevelKey = nameof(SavedLevelKey);

    [SerializeField] private LevelList _levelList;
    [SerializeField] private LevelLoadingScreen _loadingScreen;

    private int _levelCounter;

    private int _savedLevel
    {
        get => PlayerPrefs.GetInt(SavedLevelKey, 0);
        set => PlayerPrefs.SetInt(SavedLevelKey, value);
    }

    public int LevelIndex => _savedLevel;
    public int LevelCounter => _levelCounter;

    public void LoadSavedLevel()
    {
        LoadScene(_levelList.Levels[_savedLevel].ScenePath);
    }

    public void LoadNextLevel()
    {
        _savedLevel = (_savedLevel + 1) % _levelList.Levels.Count;
        LoadScene(_levelList.Levels[_savedLevel].ScenePath);
    }

    public void ReloadCurrentLevel()
    {
        LoadScene(_levelList.Levels[_savedLevel].ScenePath);
    }

    public void LoadRandomLevel()
    {
        LoadScene(Random.Range(2, 9).ToString());
    }

    private void LoadScene(string sceneName)
    {
        _levelCounter++;
        var loadingScreen = Instantiate(_loadingScreen);
        loadingScreen.LoadScene(sceneName, () => Destroy(loadingScreen.gameObject));
    }
}
