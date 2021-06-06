using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ghostAI : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 1f;
    public float timeBetweenAttacks = 2f;
    public Vector3 walkPoint;
    bool walkPointSet;

    Transform target;
    public NavMeshAgent ghost;

    public GameObject player;
    public GameObject killScreen;
    private Vector3 distanceToPatrolPoint;

    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < attackRadius) {
            // kill player 
            PlayerPrefs.SetInt("win", 0);
            PlayerPrefs.SetInt("position", 0);
            killScreen.SetActive(true);
            Time.timeScale = 0f;
        } else if (distance < lookRadius) {
            ghost.SetDestination(target.position);
            // face target when aggro
            FaceTarget();
        } else {
            // if outside range, patrol
            Patrol();
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    /**
    * draws debug sphere for sight
    */
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void Patrol() {
        // 
        if (!walkPointSet) {
            SearchWalkPoint();
        }
        if (walkPointSet) {
            ghost.SetDestination(walkPoint);
        }

        distanceToPatrolPoint = transform.position - walkPoint;

        if (distanceToPatrolPoint.magnitude < 4f) {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint() {
        // search for suitable random place to walk to
        float randomZ = Random.Range(-lookRadius, lookRadius);
        float randomX = Random.Range(-lookRadius, lookRadius);

        RaycastHit hit;

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, out hit, 2f) && hit.transform.tag == "Lawn") {
            walkPointSet = true;
        }
    }
}
