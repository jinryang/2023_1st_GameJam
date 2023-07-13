using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float playerMoveSpeed;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerMoveSpeed * Time.deltaTime;
    }
}