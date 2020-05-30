using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    [SerializeField] private EnemyPool _enemies;

    [SerializeField] private float _spawnCooldown = 0.5f;
    private float _newEnemyTimer = 0;

    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _newEnemyTimer += Time.deltaTime;

        if(_newEnemyTimer > _spawnCooldown)
        {
            _newEnemyTimer = 0;

            Enemy enemy = _enemies.GetEnemy();
            enemy.Init(_player);

            enemy.gameObject.transform.position = _transform.position;
        }
    }
}
