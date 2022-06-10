using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    [SerializeField] float scorePerKill = 10f;
    [SerializeField] GameObject ammoPickup;
    [SerializeField] GameObject[] weapons;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(Random.Range(0,4) == 2)
        {
            Instantiate(ammoPickup, transform.position, Quaternion.identity).transform.parent = null;
        }
        //else if(Random.Range(0,9) == 6)
        //{
        //    Instantiate(weapons[Random.Range(0, weapons.Length)],transform.position,Quaternion.identity).AddComponent<WeaponPickup>().transform.parent = null;
        //}
        GameObject.FindObjectOfType<Score>().IncreaseScore(scorePerKill);
        Destroy(gameObject);
    }
}
