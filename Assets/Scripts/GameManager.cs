using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData[] _gameData = null;
    private int currentLevel = 0;
    private GameUI _gameUI = null;
    private IEnumerator spawnEnemysCoroutine = null;
    private int enemyCounter = 0;

    private void Awake()
    {
        Messenger.AddListener("LOSE", Lose);
        Messenger.AddListener("ENEMY_DEAD", ChangeEnemyCounter);
        _gameUI = GetComponent<GameUI>();
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        RefreshUI();
        spawnEnemysCoroutine = SpawnEnemys();
        StartCoroutine(spawnEnemysCoroutine);
    }

    private void RefreshUI()
    {
        _gameUI.UIcounterEnemy.text = enemyCounter.ToString() + "/" + _gameData[currentLevel].EnemyCounterToWin.ToString();
    }

    private IEnumerator SpawnEnemys()
    {
        while (true)
        {
            yield return new WaitForSeconds(_gameData[currentLevel].SpawnEnemy);
            int rnd = Random.Range(0, _gameData[currentLevel].Enemys.Length);
            _gameData[currentLevel].Enemys[rnd].Create();
        }
    }

    private void Win()
    {
        _gameUI.Win();
        PlayerPrefs.SetInt($"Level{currentLevel}", 2);
        if (currentLevel < _gameData.Length - 1)
        {
            currentLevel++;
            PlayerPrefs.SetInt("Level{currentLevel}", 1);
            PlayerPrefs.SetInt("CurrentPlayer", currentLevel);
        }
        Time.timeScale = 0.001f;
    }

    private void Lose()
    {
        _gameUI.Lose();
        Time.timeScale = 0.001f;
    }

    private void ChangeEnemyCounter()
    {
        enemyCounter++;
        RefreshUI();
        if (enemyCounter == _gameData[currentLevel].EnemyCounterToWin)
        {
            StopCoroutine(spawnEnemysCoroutine);
            Invoke("Win", 2.0f);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener("ENEMY_DEAD", ChangeEnemyCounter);
        Messenger.RemoveListener("LOSE", Lose);
    }

}
