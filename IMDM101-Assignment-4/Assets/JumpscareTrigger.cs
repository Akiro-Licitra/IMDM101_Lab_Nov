using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{

    public Transform InteractorSource;
    public float InteractRange;
    public AudioSource Source;
    public AudioClip jumpscareSound;

    void Awake()
    {
        Source = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.CompareTag("Sluzzy"))
            {
                hitInfo.collider.gameObject.SetActive(false);
                Source.clip = jumpscareSound;
                Source.Play();
            }
        }

    }
}
