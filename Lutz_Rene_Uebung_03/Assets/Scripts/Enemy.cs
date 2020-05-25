using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerController _player;

    private Rigidbody2D _body;

    private Transform _transform;

    public virtual Enemy Init(PlayerController player)
    {
        _body = this.GetComponent<Rigidbody2D>();

        _player = player;
        
        return this;
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
        Vector3 direction = _player.transform.position - _transform.position;
        direction.z = 0;

        _body.MovePosition(_transform.position + (direction.normalized * _speed * Time.fixedDeltaTime));

    }

}


