using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Character : MonoBehaviour , HealthBarsUI
{
    //Attribute
    private float health;
    public float Health { get => health; set => health = (value < 0) ? 0 : value; }
    

    public float maxHealth;

    protected Animator anim;
    protected Rigidbody2D rb;

    [field: SerializeField] RectTransform rectTransform { get; set; }
    [field: SerializeField] GameObject healthBarsFill { get; set; }
    [field: SerializeField] GameObject healthBarsBG { get; set; }
    [field: SerializeField] GameObject characterObject { get; set; }
    RectTransform HealthBarsUI.rectTransform { get => rectTransform; set => rectTransform = value; }
    GameObject HealthBarsUI.healthBarsFill { get => healthBarsFill; set => healthBarsFill = value; }
    GameObject HealthBarsUI.healthBarsBG { get => healthBarsBG; set => healthBarsBG = value; }
    GameObject HealthBarsUI.characterObject { get => characterObject; set => characterObject = value; }

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


        healthBarsFill = transform.gameObject;
        healthBarsBG = transform.parent.gameObject;
        characterObject = healthBarsBG.transform.parent.parent.gameObject;

        rectTransform = healthBarsFill.GetComponent<RectTransform>();

        


    }

    // Update is called once per frame
    void Update()
    {
        updateHealthBars();
    }


    void updateHealthBars()
    {
        float percentHP = this.Health / this.maxHealth;
        Debug.Log(percentHP);
        Debug.Log(this.Health);
        Debug.Log(this.maxHealth);
        rectTransform.localScale = new Vector2(percentHP, rectTransform.localScale.y);

        healthBarsBG.transform.localScale = new Vector2(characterObject.transform.localScale.x, healthBarsBG.transform.localScale.y);
    }

    void HealthBarsUI.updateHealthBars()
    {
        updateHealthBars();
    }
}
