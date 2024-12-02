using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss_Attack : StateMachineBehaviour
{

   public Vector3 attackOffset;
	public LayerMask attackMask;
   public float speed = 8f;
   public float attackSpeedMultiplier = 2f; // multiplier for speed during attack to make it seem more scary
   public float attackRange = 5f;
   Transform player;
   Rigidbody2D rb;

   private int counter = 0;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    //Orientation for Boss
      player = GameObject.FindGameObjectWithTag("Player").transform;
      rb = animator.GetComponent<Rigidbody2D>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      

      if (counter > 300)
      {
         //Attack initiation
         if (Vector2.Distance(player.position, rb.position) <= attackRange)
         {
            animator.SetTrigger("Attack");
            speed *= attackSpeedMultiplier;
         }

      //Move boss to player
         Vector2 traget = new Vector2(player.position.x, player.position.y);
         Vector2 newPos = Vector2.MoveTowards(rb.position, traget, speed * Time.fixedDeltaTime);//Added fixed to stop animation shennanigans
      
         rb.MovePosition(newPos);

         counter = 0;
         //Debug.Log("300 frames have passed!"); //Cooldown chack
      }
      counter++;
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
    }
}
