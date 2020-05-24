using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Weapon _currentWeapon;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _weaponIndex = 0;

    Transform _transform;
    Camera _camera;

    void Start() 
    {
        this._transform = transform;
        this._camera = Camera.main;

        _weapons.Add(_currentWeapon);
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        this.Move();
        this.Rotate();
        this.SwitchWeapon();
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

    void SwitchWeapon()
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

    void Shoot()
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
        this._transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen
        
    }

    public void AddWeapon(Weapon weapon)
    {
        weapon.transform.position = _transform.position;
        weapon.transform.SetParent(_transform);

        _weapons.Add(weapon);
    }
}
