using UnityEngine;

public class ArrowFloat : MonoBehaviour
{
    public float floatSpeed = 1.0f;  // Speed of the floating motion
    public float floatHeight = 0.2f; // Height of the floating motion
    public float rotationSpeed = 50.0f; // Speed of the spinning motion

    private Vector3 startPosition;

    private void Start()
    {
        // Store the initial position of the crystal
        startPosition = transform.position;
    }

    private void Update()
    {

        // Floating effect
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // Spinning effect
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }

}