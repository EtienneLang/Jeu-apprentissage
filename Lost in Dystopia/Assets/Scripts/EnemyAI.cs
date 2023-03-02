using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform _target;


    public float speed = 200f;
    public float nextWaypointdistance = 3f;

    private Path _path;
    private int _currentWaypoint = 0;
    private bool _reachedEndOfPath = false;
    private Seeker _seeker;
    private Rigidbody2D _rb;

    public Transform enemyGFX;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        _target = player.transform;
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f,.2f);
        
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
        if (_path == null)
        {
            return;
        }

        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            _reachedEndOfPath = true;
            return;
        }
        else
        {
            _reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
         _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);
        if (distance < nextWaypointdistance)
        {
            _currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-2f, 2f, 2f);
        }
        else if (force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(2f, 2f, 2f);
        }
    }
}
