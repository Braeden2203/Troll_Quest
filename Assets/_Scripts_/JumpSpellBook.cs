using UnityEngine;

public class JumpSpellBook : MonoBehaviour
{
    Animator UIBookAnimator;

    GameObject Player;

    public BoxCollider2D SpellBookCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIBookAnimator = GetComponent<Animator>();

        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Player>().JumpSpellEnable();
            Destroy(gameObject);
        }
    }
}
