using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<Vector2> OnDamaged;
    public event Action<Vector2> OnDeath;
    public int health;
    public int maxhealth;
    private void Start()
    {
        health = maxhealth;
    }
    public void ChangeHealth(int amount, Vector2 sourcePosition)
    {
        health += amount;
        if (health > maxhealth)
            health = maxhealth;
        else if (health <= 0)
            OnDeath?.Invoke(sourcePosition);
        else if (amount < 0)
            OnDamaged?.Invoke(sourcePosition);
    }
}
