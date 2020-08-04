using UnityEngine;

public class SpawnBulletPoint : MonoBehaviour
{
    [SerializeField] private Bullet _bullet = null;

    public void Shoot()
    {
        _bullet.Create(transform.position);
    }
}
