
using UnityEngine;

public class MoveMunition : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public PolygonCollider2D parentCollider;

    private PolygonCollider2D c1;
    private Rigidbody2D rb;

    private void Start()
    {
        c1 = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreCollision(c1, parentCollider);

        GameObject[] ammos = GameObject.FindGameObjectsWithTag("Ammo");

        foreach(GameObject a in ammos)
        {
            PolygonCollider2D c2 = a.GetComponent<PolygonCollider2D>();
            Physics2D.IgnoreCollision(c1, c2);
        }

    }

    void Update()
    {
        rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Wall") || tag.Equals("Enemy"))
        {
            Destroy(transform.gameObject);
        }
    }
}
