using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : EntityBase
{
    public int hp;
    public int damagePlayer;
    public Animator anim;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HandLight")
        {
            if (anim != null)
            {
                anim.SetTrigger("AttackEnemy");
            }
            hp -= damagePlayer;
        }       

      if(hp <= 0)
        {
            Death();
            Destroy(gameObject);
            Debug.Log("EnemyDead");
        }
    }

    public void Death()
    {
        anim.SetBool("isDead", true);        
    }


}
