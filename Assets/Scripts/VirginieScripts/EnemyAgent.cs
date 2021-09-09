using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(SpriteRenderer))]
[System.Serializable]
public class EnemyAgent : MonoBehaviour
{
    public Enemy enemyType;

    [Header ("  DEBUG")]
    public float damage = 0.0f;
    public Vector3 target;
    public Vector2 speed;
    public float speedMultiplier = 1.0f;

    public HealthSystem health;
    public SpriteRenderer spriteRenderer;
    public ShipManager shipManager;
    public GameObject ship;
    public Vector2 saveVelocity;

    public virtual void Awake()
    {
        health = GetComponent<HealthSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health.SetMaxHealth(enemyType.health);
        spriteRenderer.sprite = enemyType.sprite;
        speed = new Vector2(enemyType.speed, enemyType.speed) * speedMultiplier;
        damage = enemyType.damage;
    }
    public virtual void Start()
    {
        shipManager = ShipManager.Instance;

        if (shipManager == null) return;
        ship = shipManager.gameObject;
        CalculateVelocity();
    }

    public virtual void Update()
    {
        MoveToTarget();
    }
    public void SetTarget(Vector3 value)
    {
        target = value;
    }

    public void MoveToTarget()
    {
        transform.position += (Vector3)saveVelocity;
    }

    public virtual void CalculateVelocity()
    {
        Vector2 vEnemyShip = target - transform.position;
        Vector2 dirEnemy = vEnemyShip.normalized;
        Vector2 velocity = dirEnemy * speed * Time.fixedDeltaTime;
        saveVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Bullet"))
        {
            health.TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    public void takeDamage(int value)
    {
        health.TakeDamage(value);
    }

    public virtual void SetSpeed(float _speedMultiplier) { }
    public virtual void SetDamage(float _damageMultiplier) { }
    public virtual void SetFireRate(float _rateOfFireMultiplier) { }

    public void OnDestroy()
    {
        WaveEvent.OnDestroyEnemy.Invoke(this);
    }
}
