using UnityEngine;

public class SingleFireWeapon : Weapon
{
    private AudioSource _sound;

    void Start() 
    {
        _sound = GetComponent<AudioSource>();
    }

    void Update() { }

    protected override void OnShoot(Vector3 direction)
    {
        var parentTransform = this.GetComponentInParent<Transform>();
        var projectile = _projectilePool.GetProjectile();

        projectile.transform.position = parentTransform.position;
        projectile.transform.rotation = parentTransform.rotation;
        projectile.Init(direction);

        _sound.Play();
    }
}
