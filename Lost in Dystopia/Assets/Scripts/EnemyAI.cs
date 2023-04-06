using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Diagnostics;

public class EnemyAI : MonoBehaviour
{

    private Transform _target;


    public float speed;
    public float nextWaypointdistance = 3f;
    private bool _targetIsSeen = false;
    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachedEndOfPath = false;
    private Seeker _seeker;
    private Rigidbody2D _rb;
    private GameObject player;
    public Transform enemyGFX;
    public Patrol patrol;
    public const float DISTANCE_REPERAGE = 4f;

    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<Patrol>();
        player = GameObject.FindGameObjectWithTag("Player");
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        
    }
    private void UpdatePath()
    {
        if(_seeker.IsDone())
            _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
    }

    private void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            _path = path;
            _currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position, _rb.transform.position);
        if (distance < 2f)
        {
            _target = player.transform;
            _targetIsSeen = true;
            patrol.delay = 0;
            for (int i = 0; i < patrol.targets.Length; i++)
            {
                patrol.targets[i] = player.transform;
            }
            
        }
        if (_targetIsSeen)
        {
            Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;
            _rb.AddForce(force);
        }
        
    }
}
