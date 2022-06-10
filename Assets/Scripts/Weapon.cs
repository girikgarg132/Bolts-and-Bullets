using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage = 30;
    [SerializeField] int ammoAmount = 30;
    [SerializeField] float rpm = 30f;
    [Tooltip("In Seconds")] [SerializeField] int relodTime = 30;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform pointOfFire;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] Transform bulletParent;
    [SerializeField] Text ammoText;
    [SerializeField] Text reloading;
    [SerializeField] AudioClip audioClip;
     
    Ammo ammo;
    bool canShoot = true;
    bool canReload = true;
    int currentAmmo;

    private void OnEnable()
    {
        canShoot = true;
        canReload = true;
        ammo = FindObjectOfType<Ammo>();
    }

    void Start()
    {
        currentAmmo = ammoAmount;
    }

    void Update()
    {
        if (Input.GetAxis("Fire1") == 1 && canShoot && currentAmmo > 0)
        {
            StartCoroutine(Shoot());
        }
        if (currentAmmo <= 0 && canReload)
        {
            StartCoroutine(Relod());
        }
        ammoText.text = currentAmmo + "|" + ammo.GetCurrentAmmoAmount();
    }

    IEnumerator Shoot()
    {
        currentAmmo--;
        GameObject bullet = Instantiate(bulletPrefab,pointOfFire.transform.position, pointOfFire.transform.rotation, bulletParent);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(pointOfFire.forward * bulletForce,ForceMode.Impulse);
        AudioSource.PlayClipAtPoint(audioClip,transform.position);
        canShoot = false;
        yield return new WaitForSeconds(60/rpm);
        canShoot = true;
    }

    IEnumerator Relod()
    {
        reloading.gameObject.SetActive(true);
        canReload = false;
        yield return new WaitForSeconds(relodTime);
        reloading.gameObject.SetActive(false);
        canReload = true;
        ammo.ReduceCurrentAmmo(ammoAmount);
        currentAmmo = ammoAmount;
    }

    public int GetDamage()
    {
        return damage;
    }
}
