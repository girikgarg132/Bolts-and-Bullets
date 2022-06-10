using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 40;
    PlayerHealth target;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damage);
        //StartCoroutine(target.GetComponent<DisplayDamage>().DisplayDamageVFX());
    }
}
