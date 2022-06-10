using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    Weapon currentWeapon;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetAxis("WeaponPickup") == 1)
            {
                foreach (Weapon weapon in transform)
                {
                    if (weapon.isActiveAndEnabled)
                    {
                        currentWeapon = weapon;
                        break;
                    }
                }
                currentWeapon.transform.parent = null;
                collision.gameObject.transform.parent = transform;
                Destroy(gameObject.GetComponent<WeaponPickup>());
            }
        }
    }
}
