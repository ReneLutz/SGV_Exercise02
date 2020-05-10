using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed;

    Transform _transform;
    Camera _camera;


    void Start()
    {
        this._transform = transform;
        this._camera = Camera.main;
    }

    //Standard UpdateLoop (once per Frame)
    void Update()
    {
        this.Rotate();

        float deltaSpeed = _speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * deltaSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * deltaSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * deltaSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * deltaSpeed;
        }
    }

    void Rotate(){
        Vector2 mousePos = this._camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - this._transform.position.y, mousePos.x - this._transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        this._transform.rotation = Quaternion.Euler(0, 0, angleDeg - 90);//diese -90 sind nötig für Sprites, die nach oben zeigen. Nutzen Sie andere Assets, könnte es sein, dass die das anpassen müssen
        
    }
}
