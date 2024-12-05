using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionReset : MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to the SceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the SceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset player position after a new scene loads
        transform.position = new Vector3(-18, 10.75f, -57); 
    }
}
