using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State { PATROL, TRACE, ATTACK, DIE }
    public State state = State.PATROL;

    private Transform playerTr;
    private Transform enemyTr;
    private WaitForSeconds ws;
    public float attackDist = 5f;
    public float traceDist = 10f;
    public bool isDie;
    public float dist;
    private MoveAgent moveAgent;

    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("PLAYER");
        if (player != null) playerTr = player.transform;
        enemyTr = transform;
        moveAgent = GetComponent<MoveAgent>();
        ws = new WaitForSeconds(0.3f);

    }

    private void OnEnable()
    {
        StartCoroutine(CheckState());
        StartCoroutine(Action());
    }

    IEnumerator CheckState()
    {
        while (!isDie) {
            if (state == State.DIE) yield break;
            dist = Vector3.Distance(playerTr.position, enemyTr.position); // 각 position 별 거리를 절대값으로 구함. (항상 양수)
            if (dist <= attackDist) {
                state = State.ATTACK;
            } else if (dist <= traceDist) {
                state = State.TRACE;
            } else {
                state = State.PATROL;
            }
            yield return ws;
        }
    }

    IEnumerator Action ()
    {
        while (!isDie) {
            yield return ws;
            switch (state)
            {
                case State.PATROL:
                    moveAgent.patrolling = true;
                    break;
                case State.TRACE:
                    moveAgent.traceTarget = playerTr.position;
                    break;
                case State.ATTACK:
                    moveAgent.Stop();
                    break;
                case State.DIE:
                    moveAgent.Stop();
                    break;
            }
        }
    }
}
