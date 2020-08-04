using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerShipData _playerData = null;
    [SerializeField] private ParticleSystem _boomFX = null;
    [SerializeField] private GameUI _gameUI = null;
    private int _health = 0;

    private void Start()
    {
        _health = _playerData.Health;
        _gameUI.LoadPlayerInfo(_playerData);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Messenger.Broadcast("HIT");
            other.GetComponent<Enemy>().TakeDamage(1000);
            _health--;
            if (_health <= 0)
            {
                Messenger.Broadcast("LOSE");
                Instantiate(_boomFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }            
        }
    }
}
