using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionTargetSetter : MonoBehaviour
{
    private CompanionNavigator companion;
    private NavMeshAgent _navMeshAgent;
    private BoneRespawner _boneSpawner;
    private Transform _player;
    private void Start()
    {
        companion = FindObjectOfType<CompanionNavigator>();
        _navMeshAgent = companion.GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<ReferenceHolder>().player;
    }

    public void SetSpawner(BoneRespawner boneRespawner)
    {
        _boneSpawner = boneRespawner;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(!other.gameObject.CompareTag("Floor")) return;
        Destroy(gameObject, 10f);
        
        if (companion != null)
        {
            _navMeshAgent.destination = transform.position;
        }
        Destroy(gameObject, 10f);
    }

    private void OnDestroy()
    {
        _boneSpawner.SpawnBone();
        _navMeshAgent.destination = _player.position;
    }
}
