using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    public List<Transform> wayPoints;
    public int nextIdx = 0;

    private NavMeshAgent agent;
    private readonly float patrolSpeed = 1.5f;
    private const float traceSpeed = 4.0f;
    private bool _patrolling;
    public bool patrolling {  
        get { return _patrolling; } 
        set 
        { 
            _patrolling = value; 
            if (_patrolling)
            {
                agent.speed = patrolSpeed;
                MoveWayPoint();
            }
        }
    }
    private Vector3 _traceTarget;

    public Vector3 traceTarget
    {
        get { return _traceTarget; }
        set { 
            _traceTarget = value;
            agent.speed = traceSpeed;
            TraceTarget(_traceTarget);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        var group = GameObject.Find("WayPointGroup");
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
        }
        //MoveWayPoint();
        patrolling = true;

    }

    void MoveWayPoint()
    {
        if (agent.isPathStale) return; // 경로 계산 중인 경우 true
        agent.destination = wayPoints[nextIdx].position;
        agent.isStopped = false;

    }

    private void TraceTarget(Vector3 target) { 
        if (agent.isPathStale) return;
        agent.destination = target;
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        patrolling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolling && agent.velocity.sqrMagnitude >= (0.2f * 0.2f) && agent.remainingDistance <= 0.5f) 
            // Magnitude 는 피타고라스정리로 인해 제곱 + 제곱의 제곱근으로 대각선 벡터를 구하는데 말했다시피 제곱근은 성능이 안좋음.
            // 매그니튜드의 제곱 과 비교대상의 제곱을 비교하는게 성능에 더 좋음
        {
            //nextIdx = ++nextIdx == wayPoints.Count ? 0 : nextIdx;
            nextIdx = ++nextIdx % wayPoints.Count; // 나머지 연산으로 간단하게 인덱스를 루프시킬수 있다
            MoveWayPoint();
        }
    }
}
