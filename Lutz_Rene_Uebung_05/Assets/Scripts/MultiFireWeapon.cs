using UnityEngine;

public class MultiFireWeapon : Weapon
{
    [SerializeField] private int _numberProjectiles = 3;

    private AudioSource _sound;

    private int fireAngle = 60;

    void Start() 
    {
        _sound = GetComponent<AudioSource>();
        _projectileDamage = 1;
    }

    void Update() { }

    protected override void OnShoot(Vector3 direction)
    {
        // Tranform Spaceship
        var parentTransform = this.transform.parent;

        float projectileAngle = fireAngle / (_numberProjectiles - 1);
        
        for(int i = 0; i < _numberProjectiles; i++)
        {
            Projectile projectile = _projectilePool.GetProjectile();

            projectile.transform.position = parentTransform.position;
            projectile.transform.rotation = parentTransform.rotation;
            projectile.transform.Rotate(new Vector3(0, 0, (i - 1) * projectileAngle), Space.Self);
            projectile.Init(Quaternion.AngleAxis((i - 1) * projectileAngle, Vector3.forward) * direction, _projectileDamage);
        }

        _sound.Play();
    }
}
