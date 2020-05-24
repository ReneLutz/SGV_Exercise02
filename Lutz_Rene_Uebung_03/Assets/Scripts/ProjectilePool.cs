using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    private List<Projectile> _projectiles = new List<Projectile>();

    void Start() { }

    void Update() { }

    public Projectile GetProjectile()
    {
        Projectile projectile;

        // For performance reasons LINQ is a bad idea. However in the context of this small project it has no large impact, but it increases the readability of the code.
        if (!_projectiles.Any(pro => pro.gameObject.activeSelf == false))
        {
            // No inactive object available. Create new object
            projectile = Instantiate(_projectilePrefab);
            projectile.transform.parent = this.gameObject.transform;

            _projectiles.Add(projectile);

            return projectile;
        }

        // Otherwise return first inactive object
        projectile = _projectiles.First(obj => obj.gameObject.activeSelf == false);
        projectile.gameObject.SetActive(true);

        return projectile;
    }
}
