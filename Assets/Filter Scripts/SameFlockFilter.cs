using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class SameFlockFilter : ContextFilter {
    
    public override List<Transform> Filter(FlockAgent flock, List<Transform> original) {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original) {
            FlockAgent itemAgent = item.GetComponent<FlockAgent>();
            if(itemAgent != null && itemAgent.AgentFlock == flock.AgentFlock) {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
