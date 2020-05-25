using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private PlayerController _player;

    private Rigidbody2D _body;

    private Transform _transform;

    public virtual Enemy Init(PlayerController player)
    {
        _body = this.GetComponent<Rigidbody2D>();

        _player = player;
        
        return this;
    }

    public void Explode()
    {
        gameObject.SetActive(false);
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

        Rotate();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Rotate()
    {

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
        PlayerController player = collision.otherCollider.GetComponent<PlayerController>();

        if (!player) return;

        Explode();
    }
}


