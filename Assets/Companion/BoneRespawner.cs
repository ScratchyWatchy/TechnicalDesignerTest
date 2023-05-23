using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneRespawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject bone;
    [SerializeField]
    private Transform boneRespawnPoint;
    
    void Start()
    {
        SpawnBone();
    }
    
    public void SpawnBone()
    {
        var spawnedBone = Instantiate(bone, boneRespawnPoint.position, Quaternion.identity);
        spawnedBone.GetComponent<CompanionTargetSetter>().SetSpawner(this);
    }
}
