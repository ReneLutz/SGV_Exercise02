using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected ProjectilePool _projectilePool;
    [SerializeField] protected float _projectileCooldown;

    private float nextProjectileTime;

    void Start()
    {
        this.nextProjectileTime = 0.0f;
    }

    void Update() {}

    public void Shoot(Vector3 direction)
    {
        if (nextProjectileTime < Time.time)
        {
            nextProjectileTime = Time.time + _projectileCooldown;

            OnShoot(direction);
        }
    }

    protected abstract void OnShoot(Vector3 direction);
}
