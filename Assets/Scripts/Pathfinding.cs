using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Paths
{
    public Transform targetPath;
    public bool activePath = true;
}

public class Pathfinding : MonoBehaviour
{
    public List<Paths> possiblePaths = new List<Paths>();
    public Transform pastPath;

    public bool canMove = false;
    public bool canActivate;
    public bool canRotate;
    public bool isStair = false;

    public float walkPointOffset = .5f;
    public float stairOffset = .4f;

    public Vector3 GetWalkPoint()
    {
        float stair = isStair ? stairOffset : 0;
        return transform.position + transform.up * walkPointOffset - transform.up * stair;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float stair = isStair ? .4f : 0;
        Gizmos.DrawSphere(GetWalkPoint(), .1f);

        if (possiblePaths == null)
            return;

        foreach (Paths p in possiblePaths)
        {
            if (p.targetPath == null)
                return;
            Gizmos.color = p.activePath ? Color.black : Color.clear;
            Gizmos.DrawLine(GetWalkPoint(), p.targetPath.GetComponent<Pathfinding>().GetWalkPoint());
        }
    }
}
