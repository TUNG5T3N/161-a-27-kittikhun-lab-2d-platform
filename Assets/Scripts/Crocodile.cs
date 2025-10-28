using UnityEngine;

public class Crocodile : Enemy , IShootable
{
    [SerializeField] private float atkRange;
    public Player player;
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(50);
        DamageHit = 30;

        //set atk range and target
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        //set timers variables for throwing rock
        WaitTime = 0.0f;
        ReloadTime = 5.0f;
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime; //timer
        Behavior();
    }

    public override void Behavior()
    {
        //find distance between Croccodile and Player
        Vector2 distance = transform.position - player.transform.position;

        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            Debug.Log($"{this.name} shoots rock to the {player.name}!");
            anim.SetTrigger("Shoot"); //call Shoot animation
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
