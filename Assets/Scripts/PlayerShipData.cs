using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData")]
public class PlayerShipData : ScriptableObject
{
    [SerializeField] private int _health = 100;
    [SerializeField] private int _shield = 0;
    [SerializeField] private float _fireRate = 1.0f;

    public int Health => _health;
    public int Shield => _shield;
    public float FireRate => _fireRate;

    private void OnValidate()
    {
        if (_health < 0) _health = 0;
        if (_shield < 0) _shield = 0;
        if (_fireRate < 0) _fireRate = 0;       
    }
}
