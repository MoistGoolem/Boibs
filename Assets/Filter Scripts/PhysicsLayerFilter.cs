using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/PhysicsLayer")]
public class NewBehaviourScript : ContextFilter {

    public LayerMask mask;

    public override List<Transform> Filter(FlockAgent flock, List<Transform> original) {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original) {
            if(mask == (mask | 1 << item.gameObject.layer)) {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
