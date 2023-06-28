using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterLocomotion))]
public class EnemyController : MonoBehaviour
{

    private CharacterLocomotion character;

    [SerializeField]
    private Transform target;


    [Header("Moving")]
    [SerializeField]
    [Range(-1, 1)]
    private float startDirection;

    [SerializeField]
    private Transform forwardChecker;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;


    [Header("Shooting")]
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletSpawnPosition;

    [SerializeField]
    private float fireRate = 1f;

    [SerializeField]
    private float fireCountDown;

    [SerializeField]
    private float distanceForTarget;

    private bool moveF;

    void Awake()
    {
        character = GetComponent<CharacterLocomotion>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDirection();

        if (target != null)
        {
            var dist = Vector3.Distance(target.position, transform.position);

            if (dist < distanceForTarget)
            {
                StartCoroutine(RotateToTarget());
                Shoot();
                character.Move(0, false);
            }
            else
            {
                character.Move(startDirection, false);
            }
        }

    }

    private void CheckDirection()
    {
        var colls = Physics.OverlapSphere(forwardChecker.position, groundRadius, whatIsGround);
        moveF = colls.Length > 0;

        if (!moveF) startDirection *= -1;
    }

    private void Shoot()
    {
        if (fireCountDown <= 0)
        {
            Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(forwardChecker.position, groundRadius);
    //}


    private IEnumerator RotateToTarget()
    {
        Vector3 dis = target.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(dis);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * 10f).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        yield return null;
    }
}
