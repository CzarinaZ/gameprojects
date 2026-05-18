using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{   
    //States for enemy behaviour (only Roaming for now)
    private enum State {
        Roaming
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;

    private void Awake() {

        //Grab components and set intial state
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start() {

        //Begin roaming on startup
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine() {

        //Every 2 secs, picks a new random position and move it
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition() {
        // Returns a random direction as a movement target
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
