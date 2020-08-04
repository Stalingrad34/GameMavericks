using UnityEngine;

public class PlayerBullet : Bullet
{
    [SerializeField] private BulletData _bulletData = null;
    private int damage = 0;
    private int speed = 0;

    private void Start()
    {
        base.BulletData = _bulletData;
        damage = _bulletData.Damage;
        speed = _bulletData.Speed;
    }
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public override void Create(Vector3 position)
    {
        Instantiate(this, position, Quaternion.Euler(90, 0, 0));
    }

}
