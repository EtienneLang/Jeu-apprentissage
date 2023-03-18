using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform _target;


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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        _target = player.transform;
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

        float distance = Vector3.Distance(_target.transform.position, _rb.transform.position);

        if (distance < 6f)
        {
            _target = player.transform;
            Debug.Log("Le joueur est assez proche");
            _targetIsSeen = true;
        }
        else if (!_targetIsSeen)
        {
            _target = _rb.transform;
        }

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        _rb.AddForce(force);
    }
}
