using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AkuakuController : MonoBehaviour
{
    public EntityBase target;
    public float multiplier;
    public float time;
    public LayerMask mask;
    public float angle;
    public float radius;
    public int maxObs;
    Akuaku _entity;
    ISteering _steering;
    ISteering _obsAvoidance;
    void InitializeSteering()
    {
        var seek = new Seek(transform, target.transform);
        var flee = new Flee(transform, target.transform);
        var pursuit = new Pursuit(transform, target, time);
        var evade = new Evade(transform, target, time);
        _obsAvoidance = new ObstacleAvoidance(transform, mask, maxObs, angle, radius);
        _steering = seek;
    }
    private void Awake()
    {
        _entity = GetComponent<Akuaku>();
        InitializeSteering();
    }
    private void Update()
    {
        Vector3 dirAvoidance = _obsAvoidance.GetDir();
        Vector3 dir = (_steering.GetDir() + dirAvoidance * multiplier).normalized;
        _entity.Move(dir);
        _entity.LookDir(dir);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle / 2, 0) * transform.forward * radius);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angle / 2, 0) * transform.forward * radius);
    }
}
