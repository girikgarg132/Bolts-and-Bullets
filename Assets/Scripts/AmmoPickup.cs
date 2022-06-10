using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
}
