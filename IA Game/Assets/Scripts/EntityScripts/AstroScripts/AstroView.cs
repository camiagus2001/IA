using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroView : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator anim;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();    
    }
    private void Update()
    {
        var vel = _rb.velocity.magnitude;
        anim.SetFloat("Vel", vel);

        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            anim.SetTrigger("Attack");
        }
    }
}
