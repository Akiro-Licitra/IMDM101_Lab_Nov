using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Set the destination to the player's position
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}
