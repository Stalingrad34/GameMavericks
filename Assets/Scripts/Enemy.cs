using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Create();
    public abstract void TakeDamage(int damage);
    
}
