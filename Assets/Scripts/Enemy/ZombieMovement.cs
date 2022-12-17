using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    private Transform _playerFoot;
    public Animator anim;
    public NavMeshAgent agent;
    public float reachingRadius;
    public Health health;

    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;
    private bool _isMovingValue;

    public bool IsMoving
    {
        get => _isMovingValue;

        private set
        {
            if (_isMovingValue == value) return;
            _isMovingValue = value;
            OnIsMovingValueChanged();
        }
    }

    private void Start()
    {
        _playerFoot = Player.Instance.PlayerFoot;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _playerFoot.position);
        IsMoving = distance > reachingRadius;
        if (IsMoving)
        {
            agent.isStopped = false;
            agent.SetDestination(_playerFoot.position);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("IsWalking", false);
        }

        if (health.Hp <= 0) agent.isStopped = true;
    }

    private void OnIsMovingValueChanged()
    {
        agent.isStopped = !_isMovingValue;
        if (_isMovingValue)
        {
            onStartMoving.Invoke();
        }
        else
        {
            onDestinationReached.Invoke();
        }
    }

    public void OnDie()
    {
        enabled = false;
        agent.isStopped = true;
    }
}
