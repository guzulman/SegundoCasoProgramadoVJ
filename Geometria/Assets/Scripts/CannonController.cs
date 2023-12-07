using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField]
    GameObject cannonballPrefab;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    float fireTime;

    float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= fireTime)
        {
            _currentTime = 0.0F;
            GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
        }
    }

}
