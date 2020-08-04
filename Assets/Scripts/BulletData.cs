using UnityEngine;

[CreateAssetMenu(menuName = "Data/BulletData")]
public class BulletData : ScriptableObject
{
    [SerializeField] private int _speed = 1;
    [SerializeField] private int _damage = 0;

    public int Speed => _speed;
    public int Damage => _damage;

    private void OnValidate()
    {
        if (_speed < 0) _speed = 0;
        if (_damage < 0) _damage = 0;
    }
}
