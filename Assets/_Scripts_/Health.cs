using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<Vector2> OnDamaged;
    public event Action<Vector2> OnDeath;
    public int health;
    public int maxhealth;

    [Header("Health Canisters")]
    public GameObject HCOne;
    public GameObject HCTwo;
    public GameObject HCThree;
    public GameObject HCFour;
    public GameObject HCFive;
    public GameObject HCSix;
    public GameObject HCSeven;
    public GameObject HCEight;
    public GameObject HCNine;
    public GameObject HCTen;
    public int HitPointsCount = 10;
    public GameObject GameManager;

    public GameObject Player;
    private void Start()
    {
        health = maxhealth;

        Player = GameObject.Find("Player");

        GameManager = GameObject.FindWithTag("GameManager");
    }

    private void Update()
    {
        HitPointsCount = health;
        if (HitPointsCount == 9)
        {
            HCTen.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 8)
        {
            HCNine.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 7)
        {
            HCEight.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 6)
        {
            HCSeven.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 5)
        {
            HCSix.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 4)
        {
            HCFive.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 3)
        {
            HCFour.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 2)
        {
            HCThree.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 1)
        {
            HCTwo.gameObject.SetActive(false);
        }
        else if (HitPointsCount == 0)
        {
            HCOne.gameObject.SetActive(false);
            GameManager.GetComponent<MainMenuManager>().LoadDeathScene();
        }
    }
    public void ChangeHealth(int amount, Vector2 sourcePosition)
    {
        health += amount;
        if (health > maxhealth)
            health = maxhealth;
        else if (health <= 0)
            OnDeath?.Invoke(sourcePosition);
        else if (amount < 0)
        {
            OnDamaged?.Invoke(sourcePosition);
           // HealthCanisterDamaged();
        }
    }

    //public void HealthCanisterDamaged()
   // {
   //    HitPointsCount -= 1;
   // }
}
