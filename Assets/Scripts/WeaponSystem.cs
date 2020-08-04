using System.Collections;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private PlayerShipData _playerShipData = null;
    [SerializeField] private SpawnBulletPoint[] _spawnBulletPoints = null;
    [SerializeField] private AudioSource _audio = null;
    [SerializeField] private AudioClip shoot = null;
    private float _fireRate = 1.0f;
    private IEnumerator shootingCoroutine = null;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        shootingCoroutine = Shooting();
        _fireRate = _playerShipData.FireRate;
    }

    private void Start()
    {
        StartCoroutine(shootingCoroutine);
    }

    public IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(_fireRate);
            _audio.PlayOneShot(shoot);
            foreach (var point in _spawnBulletPoints)
            {
                point.Shoot();
            }
        }
        
    }
}
