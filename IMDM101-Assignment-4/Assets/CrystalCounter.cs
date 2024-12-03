using UnityEngine;

public class CrystalCounter : MonoBehaviour
{
    public static CrystalCounter Instance; // Singleton instance to ensure one counter exists
    private int crystalCount = 0; // Tracks the total number of crystals picked up

    private void Awake()
    {
        // Ensure only one instance of this script exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
            crystalCount++;
            Debug.Log("Crystal picked up! Now have " + crystalCount);
        }
    }

    public int GetCrystalCount()
    {
        return crystalCount;
    }


}
