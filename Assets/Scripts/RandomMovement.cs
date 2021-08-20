using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
    public Vector3 topLeftBound;
    public Vector3 bottomRightBound;
    
    public float walkSpeed = .5f;

    [SerializeField]
    private Vector3 _targetPosition;

    private void Update() {
        float distanceFromTarget = Vector3.Distance(transform.position, _targetPosition);

        if (distanceFromTarget > 0.001f) {
            Move();
        } else {
            GetRandomPosition();
        }
    }

    private void Move() {
        float step = walkSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
    }

    private void GetRandomPosition() {
        _targetPosition = new Vector3(Random.Range(topLeftBound.x, bottomRightBound.x), Random.Range(bottomRightBound.y, topLeftBound.y), 0);
    }
}