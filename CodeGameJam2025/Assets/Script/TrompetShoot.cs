using UnityEngine;

public class TrompetShoot : MonoBehaviour
{
    public GameObject ammoSpawn;
    public float defaultAngleAjustment = 135;
    public GameObject[] ammos;
    public int dispertion = 90;
    public ImportShoot importShoot;

    private Camera camera;
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

        GameObject ammoClone1 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.Euler(0, 0, angle));

        MoveMunition c1MM = ammoClone1.GetComponent<MoveMunition>();
        c1MM.direction = direction;
        c1MM.parentCollider = c;

        GameObject ammoClone2 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.Euler(0, 0, angle + dispertion));
        
        float c2AngleRad = (angle + dispertion) * Mathf.Deg2Rad;
        Vector2 c2Direction = new Vector2(Mathf.Cos(c2AngleRad), Mathf.Sin(c2AngleRad));

        MoveMunition c2MM = ammoClone2.GetComponent<MoveMunition>();
        c2MM.direction = c2Direction;
        c2MM.parentCollider = c;

        GameObject ammoClone3 = Instantiate(ammo, ammoSpawn.transform.position, Quaternion.Euler(0, 0, angle - dispertion));

        float c3AngleRad = (angle - dispertion) * Mathf.Deg2Rad;
        Vector2 c3Direction = new Vector2(Mathf.Cos(c3AngleRad), Mathf.Sin(c3AngleRad));

        MoveMunition c3MM = ammoClone3.GetComponent<MoveMunition>();
        c3MM.direction = c3Direction;
        c3MM.parentCollider = c;
    }
}
