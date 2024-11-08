using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder;
    Weapon weapon;

    void Awake()
    {
        weapon = Instantiate(weaponHolder);
        weapon.gameObject.SetActive(false);
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            TurnVisual(true);
            
            weapon.parentTransform = other.transform;

            weapon.transform.SetParent(other.transform);
            
            weapon.transform.localPosition = Vector3.zero;
            
            TurnVisual(true);

            Destroy(gameObject);

            Debug.Log("Objek Player Memasuki trigger");

        }
        else 
        {

            Debug.Log("Bukan Objek Player yang memasuki Trigger");

        }
    }

    void TurnVisual(bool on)
    {

        weapon.gameObject.SetActive(on);

    }

    void TurnVisual(bool on, Weapon weapon)
    {

        weapon.gameObject.SetActive(on);

    }
}