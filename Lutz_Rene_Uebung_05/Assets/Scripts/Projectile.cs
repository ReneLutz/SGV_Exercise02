using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage { get; private set; } = 2;

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _projectileTtl = 5.0f;

    Vector3 _direction;
    Transform _transform;
    Camera _camera;

    //We set values in a Init method. Virtual, so we can extend it later :)
    public virtual Projectile Init(Vector3 direction, float damage)
    {
        this._direction = direction;
        this._direction.z = 0;
        this._direction = this._direction.normalized;

        this._projectileTtl = 5.0f;
        this.Damage = damage;

        return this;
    }

    public void Dispose()
    {
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        this._transform = this.transform;
        this._camera = Camera.main;
        this.Rotate();
    }

    void Update()
    {
        this._transform.position += this._direction * (this._speed * Time.deltaTime);

        this._projectileTtl -= Time.deltaTime;
        if (_projectileTtl <= 0) Dispose();
    }

    void Rotate()
    {
        Vector3 pos = this._transform.position + this._direction;
        float AngleRad = Mathf.Atan2(pos.y - this._transform.position.y, pos.x - this._transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
    }
}
