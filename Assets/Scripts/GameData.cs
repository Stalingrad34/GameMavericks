using UnityEngine;

[CreateAssetMenu(menuName = "Data/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private float _spawnEnemy = 0.0f;
    [SerializeField] private int _enemyCounterToWin = 0;
    [SerializeField] private Enemy[] _enemys = null;
    public float SpawnEnemy => _spawnEnemy;
    public float EnemyCounterToWin => _enemyCounterToWin;
    public Enemy[] Enemys => _enemys;

    private void OnValidate()
    {
        if (_spawnEnemy < 0) _spawnEnemy = 0.0f;
        if (_enemyCounterToWin < 0) _enemyCounterToWin = 0;
    }

}
