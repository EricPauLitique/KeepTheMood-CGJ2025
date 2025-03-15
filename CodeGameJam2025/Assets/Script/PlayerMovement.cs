
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float horizontal;
    float vertical;
    private Vector3 velocity = Vector3.zero;
    public Rigidbody2D rb;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        MovePlayer(horizontalMovement, verticalMovement);
        
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
}
