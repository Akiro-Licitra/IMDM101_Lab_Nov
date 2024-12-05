using UnityEngine;
using UnityEngine.SceneManagement;

public class SlenderExample : MonoBehaviour
{
    public Transform target;          // Player's Transform
    public Transform head;            // Head of Slenderman
    public float turnSpeed = 5.0f;    // Speed of face turning
    public float runSpeed = 5.0f;     // Running speed
    public Vector3 resetPosition;     // Position to reset Slenderman to
    public float resetInterval = 13f; // Time in seconds between resets

    private Animator anim;
    private Rigidbody rb;
    private float resetTimer;

    public GameObject whiteScreen;
    public int hp;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        // Initialize references
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        resetTimer = resetInterval;
        hp = 3;
        whiteScreen.SetActive(false);   

        // Directly play the running animation
        if (anim != null)
        {
            anim.Play("Run"); 
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Update()
    {
        // Turn face toward the player
        TurnFaceTowardPlayer();

        // Move forward constantly
        MoveForward();
        anim.Play("Run");

        // Handle position reset timer
        HandleResetTimer();
        anim.Play("Run");

    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void TurnFaceTowardPlayer()
    {
        if (target == null || head == null) return;

        // Calculate direction to the player
        Vector3 direction = (target.position - head.position).normalized;

        // Smoothly rotate the head toward the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        head.rotation = Quaternion.Slerp(head.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void MoveForward()
    {
        // Move Slenderman forward
        Vector3 forwardMovement = transform.forward * runSpeed * Time.deltaTime;

        if (rb != null)
        {
            rb.MovePosition(transform.position + forwardMovement);
        }
        else
        {
            transform.position += forwardMovement; // Fallback if Rigidbody is missing
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void HandleResetTimer()
    {
        // Count down the timer
        resetTimer -= Time.deltaTime;

        if (resetTimer <= 0f)
        {
            // Reset Slenderman's position
            transform.position = resetPosition;

            // Reset the timer
            resetTimer = resetInterval + Random.Range(0f, 13f);
        }
    }

    public void getHit()
    {
        hp--;
        if (hp != 0)
        {
            transform.position = resetPosition;
            resetTimer = resetInterval + Random.Range(14f, 32f);
        }
        else
        {
            whiteScreen.SetActive(true);
            SceneManager.LoadScene("Cutscene");
        }
    }

}
