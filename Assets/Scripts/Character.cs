using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //Attribute
    private float health;
    public float Health { get => health; set => health = (value < 0) ? 0 : value; }
    

    public float maxHealth;

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialized(int startHealth)
    {
        maxHealth = startHealth;
        Health = startHealth;
        Debug.Log($"{this.name} initial Health: {this.Health}");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //Methods
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} damage. Current Health: {Health}");

        IsDead();
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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
