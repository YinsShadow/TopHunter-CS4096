//----------------------Control the Big Robot!----------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;

    private enum State {
        Roaming
    }

    private State state;
    // Movement
    private BossPathfinding BossPathfinding;

    private void Awake() {
        BossPathfinding = GetComponent<BossPathfinding>();
        state = State.Roaming;
    }

    private void Start() {
        StartCoroutine(RoamingRoutine()); // Go!
    }

    private IEnumerator RoamingRoutine() { // Shuffle about!
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            BossPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChangeDirFloat);
        }
    }

    private Vector2 GetRoamingPosition() { //Where ya gonna go?
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
