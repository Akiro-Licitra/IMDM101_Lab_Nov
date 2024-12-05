using UnityEngine;

public class BatFloat : MonoBehaviour
{
    public float floatSpeed = 2.0f;    // Speed of the float movement
    public float floatAmplitude = 0.5f; // Height of the float movement
    public float rotationSpeed = 20.0f; // Speed of the rotation

    private Vector3 startPosition;    // Original position of the object

    void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the floating movement
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // Update the position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Apply rotation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}
