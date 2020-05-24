using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private MultiFireWeapon _weaponPrefab;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController player = collider.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Weapon weapon = Instantiate(_weaponPrefab);
            weapon.transform.parent = player.gameObject.transform;

            player.AddWeapon(weapon);

            Destroy(this.gameObject);
        }
    }
}
