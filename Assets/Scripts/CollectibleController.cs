using UnityEngine;
/************************************************************
* COMPONENT OF: Collectible Prefabs
* REGUIRED DEPENDENCIES: GameManager, Collider Trigger and
Particle System components
* DESCRIPTION: This script handles player collection logic,
plays feedback audio/paarticles.
* DATE: 9/25/2026
* AUTHOR: Lav Popov
* VERSION: 1.0
*************************************************************/


public class CollectibleController : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private GameObject collectParticlePrefab;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Call with this object collides with a trigger
    private void OnTriggerEnter(Collider other)
    // Finds the Game Manager in the Scene\
    {
        // Only executes if the collision was with the Player
        if (other.CompareTag("Player"))
        {
            // Spawn audio at the collectible's position (auto-destroys)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Spawn particles (auto-destroys if Stop Action is set to Destroy)
            Instantiate(collectParticlePrefab, transform.position, Quaternion.identity);

            // Safely destroy the collectible immediately
            Destroy(gameObject);
        }
    }

}
