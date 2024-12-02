using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack_bad : MonoBehaviour
{
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		// Define the lunge distance
		float lungeDistance = Random.Range(0f,1.5f);

		// Move the enemy forward (in 2D, use 'right' for the facing direction)
		transform.position += transform.right * lungeDistance;
		transform.position += transform.up * lungeDistance;

		// Adjust position with attack offsets (still in local space)
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x; // Offset to the right
		pos += transform.up * attackOffset.y;   // Offset upward

		// Apply the new position
		transform.position = pos;

		// Debug to confirm movement
		Debug.Log($"Enemy lunged to {transform.position}");
	}



	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
