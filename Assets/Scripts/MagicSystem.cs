using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagicSystem : MonoBehaviour
{
    public Transform firePoint;
    public GameObject magicMissilePrefab;
    public GameObject firePrefab;
    public GameObject lightningPrefab;
    public GameObject icePrefab;
    public Camera playerCamera;  // Reference to the player's camera
    bool missileMode;
    bool missileModeEnabled;
    bool fireMode;
    bool fireModeEnabled;
    bool lightningMode;
    bool lightningModeEnabled;
    bool iceMode;
    bool iceModeEnabled;

    private Vector3 worldPosition;
    private Vector3 direction;

    void Start()
    {
        SwitchToMagicMissile();
    }

    void Update()
    {
        WandRotate();

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SwitchToFire();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SwitchToLightning();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SwitchToIce();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwitchToMagicMissile();
        }

        if (Input.GetButtonDown("Fire1") && missileMode && missileModeEnabled)
        {
            ShootMagic();
        }

        if (Input.GetButtonDown("Fire1") && fireMode && fireModeEnabled)
        {
            ShootFire();
        }

        if (Input.GetButtonDown("Fire1") && lightningMode && lightningModeEnabled)
        {
            ShootLightning();
        }

        if (Input.GetButtonDown("Fire1") && iceMode && iceModeEnabled)
        {
            ShootKnifeOfIce();
        }
    }

    // Rotate the gun based on mouse position in 3D space
    void WandRotate()
    {
        Ray ray = playerCamera.ScreenPointToRay(Mouse.current.position.ReadValue());  // Ray from the camera to the mouse position
        RaycastHit hit;

        // Check if the ray hits something in the world (e.g., ground or target)
        if (Physics.Raycast(ray, out hit))
        {
            worldPosition = hit.point;
            direction = (worldPosition - firePoint.position).normalized;

            // Rotate the firePoint to face the hit position in 3D
            firePoint.LookAt(worldPosition);
        }
    }

    void ShootMagic()
    {
        Instantiate(magicMissilePrefab, firePoint.position, firePoint.rotation);
    }

    void ShootFire()
    {
        Instantiate(firePrefab, firePoint.position, firePoint.rotation);
    }

    void ShootLightning()
    {
        Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootKnifeOfIce()
    {
        Instantiate(icePrefab, firePoint.position, firePoint.rotation);
    }

    void SwitchToFire()
    {
        missileMode = false;
        missileModeEnabled = false;
        fireMode = false;
        lightningMode = false;
        lightningModeEnabled = false;
        fireModeEnabled = false;
        fireMode = true;
        fireModeEnabled = true;
        Debug.Log("Switching to Fireball!");
    }

    void SwitchToLightning()
    {
        fireMode = false;
        fireModeEnabled = false;
        iceMode = false;
        iceModeEnabled = false;
        missileMode = false;
        missileModeEnabled = false;
        lightningMode = true;
        lightningModeEnabled = true;
        Debug.Log("Switching to Lightning Bolt!");
    }

    void SwitchToIce()
    {
        lightningMode = false;
        lightningModeEnabled = false;
        fireMode = false;
        fireModeEnabled = false;
        missileMode = false;
        missileModeEnabled = false;
        iceMode = true;
        iceModeEnabled = true;
        Debug.Log("Switching to Ice Knife!");
    }

    void SwitchToMagicMissile()
    {
        iceMode = false;
        iceModeEnabled = false;
        lightningMode = false;
        lightningModeEnabled = false;
        fireMode = false;
        fireModeEnabled = false;
        missileMode = true;
        missileModeEnabled = true;
        Debug.Log("Switching to Magic Missile!");
    }
}
