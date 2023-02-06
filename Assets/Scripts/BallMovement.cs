using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour   {

    private new Rigidbody2D rigidbody2D;
    [SerializeField] float forcePower = 1.01f;
    [HideInInspector] public Vector3 inputForce;

    [HideInInspector] public MovementState moveState = MovementState.NOT_MOVING;

    void Start() {
        // Gets Components and adds if object does not have them.
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null) {
            rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    void Update() {
        float speed = rigidbody2D.velocity.magnitude;
        if (moveState == MovementState.MOVE) {
            rigidbody2D.AddForce((inputForce * forcePower), ForceMode2D.Impulse);
            moveState = MovementState.MOVING;
        }
        if (speed > 5.0f) {
            moveState = MovementState.MOVING;
        }
        if (speed < 5.0f && moveState != MovementState.NOT_MOVING) {
            moveState = MovementState.NOT_MOVING;
        }
    }
}
public enum MovementState {
    NOT_MOVING,
    DRAGGING,
    MOVE,
    MOVING
}
