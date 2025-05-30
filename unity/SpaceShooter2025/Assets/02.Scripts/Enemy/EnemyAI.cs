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
    private Animator animator;
    private EnemyFire enemyFire;
    private readonly int hashMove = Animator.StringToHash("isMove");
    private readonly int hashSpeed = Animator.StringToHash("speed");

    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("PLAYER");
        if (player != null) playerTr = player.transform;
        enemyTr = transform;
        moveAgent = GetComponent<MoveAgent>();
        animator = GetComponent<Animator>();
        enemyFire = GetComponent<EnemyFire>();
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
                    animator.SetBool(hashMove, true);
                    if (enemyFire.isFire) enemyFire.isFire = false;
                    break;
                case State.TRACE:
                    moveAgent.traceTarget = playerTr.position;
                    animator.SetBool(hashMove, true);
                    if (enemyFire.isFire) enemyFire.isFire = false;
                    break;
                case State.ATTACK:
                    moveAgent.Stop();
                    animator.SetBool(hashMove, false);
                    if (!enemyFire.isFire) enemyFire.isFire = true;
                    break;
                case State.DIE:
                    moveAgent.Stop();
                    break;
            }
        }
    }

    private void Update()
    {
        animator.SetFloat(hashSpeed, moveAgent.speed);
    }
}
