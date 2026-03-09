using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Enemy config")]
public class EnemyConfig : ScriptableObject
{
    [Header("General")]
    public float turnThreshold = .2f;
    
    [Header("Patrol")]
    public float patrolSpeed = 3;
    public float groundCheckDistance = .7f;
    public float wallCheckDistance = .5f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    [Header("Chase")]
    public float chaseSpeed = 6;
    public float chaseRange = 5;
    public LayerMask targetLayer;
    [Header("Attack")]
    public float meleeRange = 1.2f;
    public int meleeDamage = 2;
    public float meleeCooldown = 1;
    [Header("Ranged Attack")]
    public float rangedRange = 5f;
    public int rangedDamage = 1;
    public float rangedCooldown = 2;
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public float projectileSpeed = 12;
    public float projectileLifetime = 3;
    [Header("Damaged")]
    public float knockbackDuration = .2f;
    public float knockbackForce = 30;
}
