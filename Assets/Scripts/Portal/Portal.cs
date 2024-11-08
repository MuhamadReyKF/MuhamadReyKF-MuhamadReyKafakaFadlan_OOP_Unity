using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Fields for speed, rotation speed, and target position
    [SerializeField] float speed = 2f;
    [SerializeField] float rotateSpeed = 50f;
    Vector2 newPosition;

    private void Start()
    {
        // Initialize newPosition with a random position
        ChangePosition();
    }

    private void Update()
    {
        // Check the distance to newPosition; if < 0.5, set a new target position
        if (Vector3.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }
        else
        {
            // Move towards newPosition
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }

        // Rotate the portal
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Check if the player has a weapon; if not, hide the portal and disable collider
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            var playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                // Show portal if player has a weapon
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                // Hide portal if player has no weapon
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    // Randomize the position for dynamic movement
    private void ChangePosition()
    {
        newPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If portal collides with the player, load the Main scene
        if (collision.CompareTag("Player"))
        {
            LevelManager.Instance.LoadScene("Main");
        }
    }
}
