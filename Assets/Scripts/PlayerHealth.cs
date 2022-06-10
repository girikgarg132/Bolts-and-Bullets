using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 100;
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject objectToDisable;
    [SerializeField] GameObject objectToEnable;

    private void Start()
    {
        healthBar.SetMaxHealth(hitPoints);
    }

    private void Update()
    {
        healthBar.SetHealth(hitPoints);
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Time.timeScale = 0f;
            objectToEnable.SetActive(true);
            objectToDisable.SetActive(false);
        }
    }
}
