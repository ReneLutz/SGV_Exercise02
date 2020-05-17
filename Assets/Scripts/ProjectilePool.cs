using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    private List<Projectile> projectiles = new List<Projectile>();

    void Start() { }

    void Update() { }

    public Projectile GetProjectile()
    {
        Projectile projectile;

        // For performance reasons LINQ is a bad idea. However in the context of this small project it has no large impact, but it increases the readability of the code.
        if (!projectiles.Any(pro => pro.gameObject.activeSelf == false))
        {
            // No inactive object available. Create new object
            projectile = Instantiate(_projectilePrefab);
            projectile.transform.parent = this.gameObject.transform;

            projectiles.Add(projectile);

            return projectile;
        }

        // Otherwise return first inactive object
        projectile = projectiles.First(obj => obj.gameObject.activeSelf == false);
        projectile.gameObject.SetActive(true);

        return projectile;
    }
}
