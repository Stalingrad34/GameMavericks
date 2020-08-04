using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : Enemy
{
    [SerializeField] private EnemyData _enemyData = null;
    [SerializeField] private ParticleSystem _boomFX = null;
    [SerializeField] private float speedRotation = 0.0f;
    private int _health = 0;
    private Rigidbody _rigidbody = null;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.angularVelocity = Random.insideUnitSphere * speedRotation;
        _health = _enemyData.Health;
    }

    private void Update()
    {
        transform.Translate(Vector3.back * _enemyData.Speed * Time.deltaTime, Space.World);
    }


    public override void Create()
    {
        Vector3 spawnPosition = _enemyData.CreateSpawnPosition();
        Instantiate(this, spawnPosition, Quaternion.identity);
    }

    public override void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Instantiate(_boomFX, transform.position, Quaternion.identity);
            Messenger.Broadcast("ENEMY_DEAD");
            Destroy(gameObject);
        }
    }
}
