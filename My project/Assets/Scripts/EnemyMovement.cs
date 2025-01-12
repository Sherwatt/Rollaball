using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; //the game always knows where the player is
    private NavMeshAgent navMeshAgent; 
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // allows the enemy to interact with the NavMesh
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) //as long as the player is still alive
        {
            navMeshAgent.SetDestination(player.position); //the enemy will chase it
        }
    }
}
