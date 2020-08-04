using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _speed = 1;
    [SerializeField] private int _shield = 0;
    [SerializeField] private float _fireRate = 1.0f;
    [SerializeField] private float spawnMinX = 0.0f;
    [SerializeField] private float spawnMaxX = 0.0f;
    [SerializeField] private float spawnMinZ = 0.0f;
    [SerializeField] private float spawnMaxZ = 0.0f;

    public int Health => _health;
    public int Speed => _speed;
    public int Shield => _shield;
    public float FireRate => _fireRate;

    private void OnValidate()
    {
        if (_health < 0) _health = 0;
        if (_shield < 0) _shield = 0;
        if (_fireRate < 0) _fireRate = 0;
        if (_speed < 0) _speed = 0;
    }

    public Vector3 CreateSpawnPosition()
    {
        float rndX = Random.Range(spawnMinX, spawnMaxX);
        float rndZ = Random.Range(spawnMinZ, spawnMaxZ);

        return new Vector3(rndX, 0, rndZ);
    }
}
