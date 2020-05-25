using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private ParticleSystem _explosion;

    private Vector3 _direction;

    private PlayerController _player;

    private Rigidbody2D _body;
    private CircleCollider2D _collider;

    private Transform _transform;

    public virtual Enemy Init(PlayerController player)
    {
        _body = this.GetComponent<Rigidbody2D>();
        _collider = this.GetComponent<CircleCollider2D>();

        _body.simulated = true;
        _collider.enabled = true;
        
        _player = player;
        
        return this;
    }

    public void Explode()
    {
        //Disable collisions
        _body.simulated = false;
        _collider.enabled = false;

        _explosion.Play();

        StartCoroutine(Disable());
    }

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;

        _speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _direction = _player.transform.position - _transform.position;
        _direction.z = 0;
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float angleRad = Mathf.Atan2(_direction.y, _direction.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        _body.MoveRotation(angleDeg - 90);
    }

    private void Move()
    {
        _body.MovePosition(_transform.position + (_direction.normalized * _speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile = collider.GetComponent<Projectile>();

        if (!projectile) return;

        projectile.Dispose();

        Explode();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (!player) return;

        Explode();
    }

    private IEnumerator Disable()
    {
        while(_explosion.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}


