using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {
        GoToBase,
        AttackBase,
        ChasePlayer,
        AttackPlayer
    }

    public EnemyState currentState;
    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    private UnityEngine.AI.NavMeshAgent agent;

    public float fireRate;
    public GameObject bulletPrefab;
    public float lastShootTime;

    // Animator animator;

    private void Awake() {
        baseTransform = GameObject.Find("Base").transform;
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        // animator = GetComponentInParent<Animator>();
    }
    void Update() {
        if (currentState == EnemyState.GoToBase) {
            GoToBase();
        } else if (currentState == EnemyState.AttackBase) {
            AttackBase();
        } else if (currentState == EnemyState.ChasePlayer) {
            ChasePlayer();
        } else if (currentState == EnemyState.AttackPlayer) {
            AttackPlayer();
        }
    }

    void GoToBase() { 
        print("GoToBase");
        // animator.SetBool("Shooting", false);
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if (sightSensor.detectedObject != null) {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase < baseAttackDistance) {
            currentState = EnemyState.AttackBase;
        }
     }
    void AttackBase() { 
        agent.isStopped = true;
        print("AttackBase"); 
        LookTo(baseTransform.position);
        Shoot();
    }

    void ChasePlayer() { 
        print("ChasePlayer");
        // animator.SetBool("Shooting", false);
        agent.isStopped = false;
        if (sightSensor.detectedObject == null) {
            currentState = EnemyState.GoToBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer < playerAttackDistance) {
            currentState = EnemyState.AttackPlayer;
        }
     }
    void AttackPlayer() { 
        print("AttackPlayer");
        agent.isStopped = true;
        if (sightSensor.detectedObject == null) {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.1f) {
            currentState = EnemyState.ChasePlayer;
        }
     }

    void Shoot() {
        // animator.SetBool("Shooting", true);
        var timeSinceLastShoot = Time.time - lastShootTime;
        if (timeSinceLastShoot > fireRate) {
            lastShootTime = Time.time;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void LookTo(Vector3 targetPosition) {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}
