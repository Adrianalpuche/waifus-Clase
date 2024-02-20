using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    private EnemyHeal _enemyHeal;
    private  NavMeshAgent nav;

    private Transform  player;

    // Start is called before the first frame update
    void Start()
    {
        _enemyHeal = GetComponent<EnemyHeal>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyHeal.vidaActual > 0) 
        {
            nav.SetDestination(player.position);
        }
        else {
            nav.enabled = false;
        }
    }
}
