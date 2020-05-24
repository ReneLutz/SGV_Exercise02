public class EnemyPool : ObjectPool<Enemy>
{

    // void Start() { }
    // 
    // void Update() { }

    public Enemy GetEnemy()
    {
        return GetObject();
    }
}
