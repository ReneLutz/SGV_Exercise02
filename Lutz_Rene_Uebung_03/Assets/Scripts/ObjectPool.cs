using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{

    [SerializeField] protected T _objectPrefab;

    private List<T> _objects = new List<T>();

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    protected T GetObject()
    {
        foreach (T obj in _objects)
        {
            if (obj.gameObject.activeSelf == false)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }


        // No inactive object available. Create new object
        T objectCopy = Instantiate(_objectPrefab);
        objectCopy.transform.parent = this.gameObject.transform;

        _objects.Add(objectCopy);

        return objectCopy;
    }
}
