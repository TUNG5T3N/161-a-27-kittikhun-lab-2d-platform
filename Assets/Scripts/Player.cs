using UnityEngine;

public class Player : Character , IShootable
{
    [field: SerializeField] public GameObject Bullet { get ; set ; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(100);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log($"{this.name} Hit with {enemy.name}!");
            OnHitWith(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update: " + Time.deltaTime);
        Shoot();
    }

    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate: " + Time.deltaTime);
        WaitTime += Time.fixedDeltaTime;
    }

    public void Shoot()
    {
        if(Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapon(20, this);

            WaitTime = 0.0f; //reset waittime
        }
    }
}
