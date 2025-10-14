using UnityEngine;

public class Character : MonoBehaviour
{
    //Attribute
    private int health;
    public int Health { get => health; set => health = (value < 0) ? 0 : value; }

    protected Animator anim;
    protected Rigidbody2D rb;

    //Methods
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} damage. Current Health: {Health}");
    }

    public bool IsDead()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead and destroyed.");
            return true;
        }
        else return false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
