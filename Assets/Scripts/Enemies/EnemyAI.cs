//---Control the Robots!---

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State {
        Roaming
    }

    private State state;
    // Movement
    private EnemyPathfinding enemyPathfinding;

    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start() {
        StartCoroutine(RoamingRoutine()); //Shuffle about!
    }

    private IEnumerator RoamingRoutine() { //Move it or lose it!
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition() { //Where ya goin?
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
