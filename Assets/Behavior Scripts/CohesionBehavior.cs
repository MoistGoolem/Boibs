using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FlockBehavior {

    //if there are no neighbors, return no adjustment
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock) {
        if(context.Count == 0) {
            return Vector2.zero;
        }

        //add points together and average
        Vector2 cohesionMove = Vector2.zero;
        foreach(Transform item in context) {
            cohesionMove += (Vector2)item.position;
        }

        cohesionMove /= context.Count;

        //Create offset from agent position
        cohesionMove -= (Vector2)agent.transform.position;
        return cohesionMove;

    }
}
