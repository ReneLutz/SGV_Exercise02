public class ProjectilePool : ObjectPool<Projectile>
{
    void Start() { }

    void Update() { }

    public Projectile GetProjectile()
    {
        return GetObject();
    }
}
