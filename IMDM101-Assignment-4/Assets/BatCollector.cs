using UnityEngine;

public class BatCollector : MonoBehaviour
{

    public Transform InteractorSource;
    public float PickUpRange, HitRange;
    public bool hasBat;
    public SlenderExample slendermen;
    public AudioSource Source;
    public AudioClip clip;

    public GameObject pickupText, useText, batMarker;

    void Awake()
    {
        Source = GetComponent<AudioSource>();
        hasBat = false;
        pickupText.SetActive(false);
        useText.SetActive(false);   
        batMarker.SetActive(false);
    }


    void Update()
    {
        if (hasBat)
        {
            batMarker.SetActive(true);
        }
        else
        {
            batMarker.SetActive(false);
        }

        // if no bat is held, check area ahead for any bats
        if (!hasBat) { 
            if (useText.activeSelf)
            {
                useText.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, PickUpRange))
                {
                    if (hitInfo.collider.gameObject.CompareTag("Bat"))
                    {
                        hitInfo.collider.gameObject.SetActive(false);
                        hasBat = true;
                    }
                }
            }
            else
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, PickUpRange))
                {
                    if (hitInfo.collider.gameObject.CompareTag("Bat"))
                    {
                        pickupText.SetActive(true);
                    }
                }
                else
                {
                    if (pickupText.activeSelf)
                    {
                        pickupText.SetActive(false);
                    }
                }
            }
        }

        if (hasBat) { 
            if (pickupText.activeSelf)
            {
                pickupText.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, HitRange))
                {
                    if (hitInfo.collider.gameObject.CompareTag("Slender"))
                    {
                        Source.clip = clip;
                        Source.Play();
                        hasBat = false;
                        slendermen.getHit();
                    }
                }
            }
            else
            {
                Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
                if (Physics.Raycast(r, out RaycastHit hitInfo, HitRange))
                {
                    if (hitInfo.collider.gameObject.CompareTag("Slender"))
                    {
                        useText.SetActive(true);
                    }
                }
                else
                {
                    if (useText.activeSelf)
                    {
                        useText.SetActive(false);
                    }
                }
            }
        }


    }
}
