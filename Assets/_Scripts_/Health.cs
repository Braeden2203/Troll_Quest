using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnDamaged;
    public event Action OnDeath;
    public int health;
    public int maxhealth;
    private void Start()
    {
        health = maxhealth;
    }
    public void ChangeHealth(int amount)
    {
        health += amount;
        if (health > maxhealth)
            health = maxhealth;
        else if (health <= 0)
            OnDeath?.Invoke();
        else if (amount < 0)
            OnDamaged?.Invoke();
    }
}
