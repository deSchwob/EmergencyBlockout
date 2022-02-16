using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float moveSpeed = 0.5f;
    private float scrollSpeed = 10f;

    public float maxX = 40.0f;
    public float minX = -55.0f;
    public float maxZ = 80.0f;
    public float minZ = -30.0f;

    float horizontalInput;
    float verticalInput;
    float wheelInput;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        wheelInput = Input.GetAxis("Mouse ScrollWheel");
    }

    void FixedUpdate()
    {
        if (transform.position.z > maxZ) transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        if (transform.position.z < minZ) transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        if (transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        if (transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);

        if (Input.GetAxisRaw("Horizontal") != 0 || verticalInput != 0)
        {
            transform.position += moveSpeed * new Vector3(horizontalInput, 0, verticalInput);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }
    }
}