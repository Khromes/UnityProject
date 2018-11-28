using UnityEngine;

public class PlayerJump : MonoBehaviour {


    private Rigidbody rb;
    public BoxCollider col;
    public LayerMask groundlayers;
    public float jumpForce = 6;
    public float distanceToGround = .6f;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void FixedUpdate() {

        
            Debug.Log(isGrounded());
        

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }
}
