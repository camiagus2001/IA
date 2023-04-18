using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogModel : MonoBehaviour
{
    public float jumpSpeed;
    public float maxTime;
    AstroModel _lastPlayerTouch;
    bool _touchPlayer;
    bool _touchFloor;
    public Vector2 range;
    Vector3 _initPosition;

    float _timer;
    Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _initPosition = transform.position;
    }
    public Vector3 GetJumpDirection()
    {
        var x = Random.Range(-range.x, range.x);
        var z = Random.Range(-range.y, range.y);
        var pos = new Vector3(x, 0, z) + _initPosition;
        //b-a
        //a= frog = transform.position
        //b= pos
        return (pos - transform.position).normalized + Vector3.up;
    }
    public void Jump(Vector3 dir)
    {
        _rb.AddForce(dir * jumpSpeed, ForceMode.Impulse);
    }
    public float GetRandomTime()
    {
        return Random.Range(0, maxTime);
    }
    public void RunTimer()
    {
        _timer -= Time.deltaTime;
    }
    public void Dead()
    {
        print("DEADD");
        Destroy(gameObject);
    }
    public void Attack(AstroModel player)
    {
        if (player != null)
            Destroy(player.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        AstroModel player = collision.gameObject.GetComponent<AstroModel>();
        if (player != null)
        {
            _touchPlayer = true;
            _lastPlayerTouch = player;
        }
        else
        {
            _touchFloor = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        AstroModel player = collision.gameObject.GetComponent<AstroModel>();
        if (player == null)
        {
            _touchFloor = false;
        }
    }
    public float CurrentTimer
    {
        set
        {
            _timer = value;
        }
        get
        {
            return _timer;
        }
    }
    //public bool IsTouchPlayer => _touchPlayer;
    public bool IsTouchPlayer
    {
        get
        {
            return _touchPlayer;
        }
    }
    public bool IsTouchFloor
    {
        get
        {
            return _touchFloor;
        }
    }
    public AstroModel LastPlayerTouch => _lastPlayerTouch;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var pos = _initPosition;
        if (pos == Vector3.zero)
        {
            pos = transform.position;
        }
        Gizmos.DrawWireCube(pos, new Vector3(range.x, 1, range.y));
    }
}
