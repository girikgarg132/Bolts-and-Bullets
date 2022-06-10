using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] ParticleSystem hitEffect;
    //[Tooltip("Time taken to destroy the Hit Particle Effects after Instantiating.")][SerializeField] float destroyHitEffectTime = 5f;

    GameObject weapons;
    Weapon currentWeapon;

    void Start()
    {
        weapons = GameObject.FindGameObjectWithTag("Weapons");
        for (int i=0; i < weapons.transform.childCount; i++)
        {
            Weapon weapon = weapons.transform.GetChild(i).GetComponent<Weapon>();
            if (weapon.isActiveAndEnabled)
            {
                currentWeapon = weapon;
                break;
            }
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(currentWeapon.GetDamage());
        }
        //Destroy(Instantiate(hitEffect,transform),destroyHitEffectTime);
        Destroy(gameObject);
    }
}
