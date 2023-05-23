using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionNavigator : MonoBehaviour
{
   public Transform goal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [ContextMenu("D")]
    public void NavigateToGoal()
    {
        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }
}
