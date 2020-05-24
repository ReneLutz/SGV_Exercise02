using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private MultiFireWeapon _weapon;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();

        if (player != null)
        {
            player.AddWeapon(_weapon);

            Destroy(this.gameObject);
        }
    }
}
