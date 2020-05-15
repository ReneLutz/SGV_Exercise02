using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] Projectile _projectilePrefab;
    [SerializeField] float _projectileCooldown;
    [SerializeField] float _projectileTtl = 5f;

    private float nextProjectileTime;

    Transform _transform;
    Camera _camera;

    void Start()
    {
        this._transform = transform;
        this._camera = Camera.main;

        this.nextProjectileTime = 0.0f;
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        this.Move();
        this.Rotate();
        this.Shoot();
    }

    void Move()
    {
        float deltaSpeed = _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            this._transform.position += Vector3.up * deltaSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this._transform.position += Vector3.left * deltaSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            this._transform.position += Vector3.down * deltaSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this._transform.position += Vector3.right * deltaSpeed;
        }
    }

    void Shoot()
    {
        // With GetKey the user would be able to shoot projectiles as long as he presses the LMB
        if (Input.GetKey(KeyCode.Mouse0) && nextProjectileTime < Time.time)
        {
            nextProjectileTime = Time.time + _projectileCooldown;

            Vector3 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);

            var projectileCopy = Instantiate(_projectilePrefab, _transform.position, Quaternion.identity).Init(mousePos - _transform.position);

            Destroy(projectileCopy.gameObject, _projectileTtl);
        }
    }

    void Rotate(){
        Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - this._transform.position.y, mousePos.x - this._transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen
        
    }
}
