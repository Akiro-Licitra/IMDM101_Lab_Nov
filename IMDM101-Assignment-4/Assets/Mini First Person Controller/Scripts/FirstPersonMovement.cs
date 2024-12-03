using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    public static bool hasRed, hasPink, hasBlue;
    public static bool usedRed, usedPink, usedBlue;
    public static bool finished;
    public AudioSource source;
    public AudioClip clip;

    public GameObject player;
    public Camera playerCamera;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        hasRed = false;
        hasPink = false;
        hasBlue = false;
        usedRed = false;
        usedPink = false;
        usedBlue = false;
        finished = false;
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.linearVelocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.linearVelocity.y, targetVelocity.y);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            ChangeSceneWithAudio("LabScene");
        }
    }

    public void ChangeSceneWithAudio(string sceneName)
    {
        StartCoroutine(PlayAudioAndChangeScene(sceneName));
    }

    private IEnumerator PlayAudioAndChangeScene(string sceneName)
    {

        //player.SetActive(false);
        //playerCamera.gameObject.SetActive(false);

        source.clip = clip;
        source.Play();

        // Wait for a short time to ensure the clip starts playing
        yield return new WaitForSeconds(0.1f);

        // Optional: Wait for the audio clip to finish before switching scenes
        yield return new WaitForSeconds(clip.length);

        SceneManager.LoadScene(sceneName);
    }

}