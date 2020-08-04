using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public BulletData BulletData {get; set;}
    public abstract void Create(Vector3 transform);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(BulletData.Damage);
        }
    }
}
