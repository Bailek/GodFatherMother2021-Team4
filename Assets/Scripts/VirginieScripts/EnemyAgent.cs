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
        speed = new Vector2(enemyType.speed, enemyType.speed);
        damage = enemyType.damage;
    }
    public virtual void Start()
    {
        shipManager = ShipManager.Instance;

        if (shipManager == null) return;
        ship = shipManager.gameObject;
    }

    public virtual void Update()
    {
        if (shipManager != null || ship != null)
        {
            MoveToTarget();
            RotateTowardTarget();
        }
        else
        {
            ContinueMove();
        }
    }

    private void ContinueMove()
    {
        transform.position += (Vector3)saveVelocity;
    }
    public void SetTarget(Vector3 value)
    {
        target = value;
    }

    public void MoveToTarget()
    {
        Vector2 vEnemyShip = target - transform.position;
        Vector2 dirEnemy = vEnemyShip.normalized;
        Vector2 velocity = dirEnemy * speed * Time.fixedDeltaTime;

        transform.position += (Vector3)velocity;

        saveVelocity = velocity;
    }

    public void RotateTowardTarget()
    {
        Vector3 forward = transform.position + Vector3.up;
        Vector3 vForwardToShip = ship.transform.position - forward;
        Vector3 dirToShip = vForwardToShip.normalized;
        float angle = Mathf.Atan2(dirToShip.y, dirToShip.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public virtual void SetSpeed(float _speedMultiplier) { }
    public virtual void SetDamage(float _damageMultiplier) { }
    public virtual void SetFireRate(float _rateOfFireMultiplier) { }
}
