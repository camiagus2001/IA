using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour
{
    public float range;
    public float angle = 120;
    public LayerMask mask;
    public GameObject lights;
    public bool CheckRange(Transform target)
    {
        //b-a
        //float distance = (target.position - transform.position).magnitude
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < range;
    }
    public bool CheckAngle(Transform target)
    {
        Vector3 foward = transform.forward;
        //b-a
        Vector3 dirToTarget = (target.position - transform.position);
        float angleToTarget = Vector3.Angle(foward, dirToTarget);
        return angle / 2 > angleToTarget;
    }

    public bool CheckView(Transform target)
    {
        Vector3 diff = (target.position - transform.position);
        Vector3 dirToTarget = diff.normalized;
        float distanceToTarget = diff.magnitude;

        RaycastHit hit;

        return !Physics.Raycast(transform.position, dirToTarget, out hit, distanceToTarget, mask);
    }
    public void SetLights(bool v)
    {
        if (lights.activeInHierarchy != v)
            lights.SetActive(v);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle / 2, 0) * transform.forward * range);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angle / 2, 0) * transform.forward * range);
    }
}
