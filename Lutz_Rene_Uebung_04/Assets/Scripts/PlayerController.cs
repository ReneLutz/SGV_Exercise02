using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Weapon _currentWeapon;

    private Rigidbody2D _body;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _weaponIndex = 0;

    private Vector3 _direction;

    Transform _transform;
    Camera _camera;

    void Start() 
    {
        this._transform = transform;
        this._camera = Camera.main;

        _body = this.GetComponent<Rigidbody2D>();

        _weapons.Add(_currentWeapon);
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        this.MovementInputs();
        this.SwitchWeapon();
        this.Shoot();
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        _body.MovePosition(_transform.position + (_direction * _speed * Time.fixedDeltaTime));
    }

    private void MovementInputs()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);        
    }

    private void SwitchWeapon()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            _weaponIndex = (_weapons.Count + _weaponIndex + 1) % _weapons.Count;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _weaponIndex = (_weapons.Count + _weaponIndex - 1) % _weapons.Count;
        }

        if (_weapons.Count > 1)
        {
            _currentWeapon = _weapons[_weaponIndex];
        }
    }

    private void Shoot()
    {
        // With GetKey the user would be able to shoot projectiles as long as he presses the LMB
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);

            _currentWeapon.Shoot(mousePos - _transform.position);
        }
    }

    void Rotate(){
        Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - this._transform.position.y, mousePos.x - this._transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        _body.MoveRotation(angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen 
    }

    public void AddWeapon(Weapon weapon)
    {
        weapon.transform.position = _transform.position;
        weapon.transform.SetParent(_transform);

        _weapons.Add(weapon);
    }
}
