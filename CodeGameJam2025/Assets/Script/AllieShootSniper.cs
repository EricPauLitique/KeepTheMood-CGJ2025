using UnityEngine;

public class AllieShootSniper : MonoBehaviour
{
    public Camera camera;
    public GameObject ammoSpawn;
    public float defaultAngleAjustment = -45;
    public GameObject[] ammos;
    public ImportShoot importShoot;

    private Animator animator;
    private float angle;
    private Vector2 direction;
    private int oldAmmoFired = -1;
    private PolygonCollider2D c;

    private void Start()
    {
        camera = importShoot.camera;
        animator = GetComponent<Animator>();
        c = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        updateOrientation();
        wantToFire();
    }

    void wantToFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("AskToFire");
        }
    }

    void updateOrientation()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = camera.ScreenToWorldPoint(mousePosition);
        direction = (Vector2)(worldMousePosition - transform.position);

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + defaultAngleAjustment);
    }

    void fire()
    {
        int rAmmo = Random.Range(0, ammos.Length);

        if (rAmmo == oldAmmoFired)
            rAmmo = (rAmmo + 1) % ammos.Length;

        GameObject ammo = ammos[rAmmo];
        oldAmmoFired = rAmmo;

        GameObject balle = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.Euler(0, 0, angle));

        MoveMunition mm = balle.GetComponent<MoveMunition>();
        mm.direction = direction;
        mm.parentCollider = c;
        mm.tag = "AmmoSniper";
        mm.speed = 20;
    }
}
