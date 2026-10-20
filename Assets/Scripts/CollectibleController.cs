/************************************************************

COMPONENT OF: Collectible Prefabs

REQUIRED DEPENDENCIES: GameManager, Collider Trigger and
Particle System components

DESCRIPTION: This script handles player collection logic,
plays feedback audio/particles, and continuously rotates the collectible.

DATE: 9/25/2026

AUTHOR: Lav Popov

VERSION 1.1: Add a behavior so that the Collectible rotates slowly about the y-axis.
*************************************************************/
// Particle effect spawned upon collection
[SerializeField] private GameObject collectParticlePrefab;

// Rotation speed along the Y axis in degrees per second
[SerializeField] private float rotationSpeed = 45.0f;

// Reference to the GameManager in the scene
private GameManager gameManager;

void Start()
{
    // Finds the Game Manager in the Scene
    gameManager = FindAnyObjectByType<GameManager>();
}

void Update()
{
    // Call rotation handling method every frame
    RotateCollectible();
}

// Rotates the GameObject continuously around its Y axis
private void RotateCollectible()
{
    // Rotates around the Vector3.up (Y axis) at a constant rate using Time.deltaTime
    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
}

// Called when this object collides with a trigger
private void OnTriggerEnter(Collider other)
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