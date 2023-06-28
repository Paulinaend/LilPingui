using System.Collections;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public bool AirControl = true;

    private Rigidbody rbody;
    private bool facingRight = true;
    private bool grounded;

    void Awake()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var colls = Physics.OverlapSphere(groundCheck.position, groundRadius, whatIsGround);
        grounded = colls.Length > 0;
    }

    public void Move(float direction, bool jump)
    {

        if (grounded || AirControl)
        {
            //rbody.velocity = new Vector2(direction * maxSpeed, rbody.velocity.y);

            if (facingRight && direction < 0)
            {
                StartCoroutine(RotateToBack());
            }

            else if (direction > 0 && !facingRight)
            {
                StartCoroutine(RotateToFront());
            }

            rbody.velocity = new Vector3(rbody.velocity.x, rbody.velocity.y, direction * maxSpeed);
        }

        if (jump && grounded)
        {
            //rbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rbody.velocity = new Vector2(rbody.velocity.x / 3, jumpForce);
        }
    }


    private IEnumerator RotateToBack()
    {
        facingRight = !facingRight;
        for (float y = 0; y <= 180; y += 10)
        {
            Vector3 rotation = new Vector3(0f, y, 0f);
            transform.rotation = Quaternion.Euler(rotation);
            yield return null;
        }
    }

    private IEnumerator RotateToFront()
    {
        facingRight = !facingRight;
        for (float y = 180; y >= 0; y -= 10)
        {
            Vector3 rotation = new Vector3(0f, y, 0f);
            transform.rotation = Quaternion.Euler(rotation);
            yield return null;
        }
    }
}