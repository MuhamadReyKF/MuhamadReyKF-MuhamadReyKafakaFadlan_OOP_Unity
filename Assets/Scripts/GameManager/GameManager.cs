using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static LevelManager LevelManager { get; private set; }

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Find the LevelManager component in the scene (or attach it as a child of GameManager)
        LevelManager = FindObjectOfType<LevelManager>();

        // Remove all objects except Camera and Player
        RemoveAllObjectsExcept("MainCamera", "Player");
    }

    private void RemoveAllObjectsExcept(string cameraTag, string playerTag)
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        
        foreach (GameObject obj in allObjects)
        {
            // If the object is not the Camera or Player, destroy it
            if (obj.CompareTag(cameraTag) || obj.CompareTag(playerTag))
            {
                continue;
            }
            
        }
    }
}
