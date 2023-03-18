using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float size;
    private Vector3 _min;
    private Vector3 _max;
    public EdgeCollider2D CameraCollider;
    public Camera camera;
    private void Start()
    {
        camera.orthographicSize = size;
        _min = CameraCollider.bounds.min;
        _max = CameraCollider.bounds.max;
    }
    // Update is called once per frame
    void Update()
    {
        //Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        //transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, _min.x + GetComponent<Camera>().orthographicSize, _max.x - GetComponent<Camera>().orthographicSize),
            Mathf.Clamp(target.position.y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize),
            transform.position.z
        );
    }
}
