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
    public Transform target;
    public Vector2 speed;

    private HealthSystem health;
    private SpriteRenderer spriteRenderer;
    public ShipManager shipManager;
    public GameObject ship;

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
        if (shipManager == null || ship == null) return;

        MoveToTarget();
        RotateTowardShip();
    }

    public void SetTarget(Transform value)
    {
        target = value;
    }

    public virtual void MoveToTarget()
    {
        Vector2 vEnemyShip = target.position - transform.position;
        Vector2 dirEnemy = vEnemyShip.normalized;
        Vector2.ClampMagnitude(speed, enemyType.maxSpeed);
        Vector2 velocity = dirEnemy * speed * Time.fixedDeltaTime;

        transform.position += (Vector3)velocity;
    }

    public void RotateTowardShip()
    {
        float angle = 0f;
        Vector3 forward = transform.position + Vector3.up;
        Vector3 vForwardToTarget = ship.transform.position - forward;
        Vector3 dirForwardToTarget = vForwardToTarget.normalized;
        angle = Mathf.Atan2(dirForwardToTarget.y, dirForwardToTarget.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public virtual void SetSpeed(float _speedMultiplier) { }
    public virtual void SetDamage(float _damageMultiplier) { }
    public virtual void SetFireRate(float _rateOfFireMultiplier) { }
}
