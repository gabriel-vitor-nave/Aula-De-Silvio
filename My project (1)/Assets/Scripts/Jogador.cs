using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float speed = 6f;
    public float gravidade = -9.81f;


    public float forcaPulo = 2f;
    public GroundCheck gc;
    private bool isGrounded;


    private CharacterController controller;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = gc.isGrounded;

        // Movimento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(forcaPulo * -2f * gravidade);
        }

        // Gravidade
        velocity.y += gravidade * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}