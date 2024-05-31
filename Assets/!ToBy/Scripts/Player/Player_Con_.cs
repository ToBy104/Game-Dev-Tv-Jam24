using UnityEngine;


public class Player_Con_ : MonoBehaviour
{
    [Header("------ Assets ------")]

    [Header("------ Move ------")]
    [SerializeField] private float speed;

    [Header("------ Ground Check ------")]
    private float GroundedRadius;
    public LayerMask whatIsGround;
    bool isGrounded;

    private void Update()
    {
        Move();

        GroundedCheck();
    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 move_Dir_ = transform.forward * Vertical + transform.right * Horizontal;

        transform.localPosition += move_Dir_.normalized * speed * Time.deltaTime;
    }

    private void GroundedCheck() => isGrounded = Physics.CheckSphere(transform.position, GroundedRadius, whatIsGround, QueryTriggerInteraction.Ignore);


    private void Jump()
    {
        if (isGrounded)
        {

        }
    }
}
