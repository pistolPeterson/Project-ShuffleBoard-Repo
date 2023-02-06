using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script that renders the drag line to show how much force will be applied to the ball on push.
/// When mouse1 button released, ball will be moved.
/// </summary>
public class DragLine : MonoBehaviour {
    private LineRenderer lineRenderer;
    [SerializeField] private BallMovement ballMovement;
    [SerializeField] private Material material;
    [SerializeField] private float startWidth = 1.0f;
    [SerializeField] private float endWidth = 0.0f;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private int sortingLayerOrder = 1;

    [SerializeField] private float lineLimit = 1f;

    void Start()    {
        // Gets Components and adds if object does not have them.        
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null) {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // LineRenderer properties
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;

        // Visual Stuf
        lineRenderer.material = material;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
        lineRenderer.alignment = LineAlignment.TransformZ;
        lineRenderer.sortingOrder = sortingLayerOrder;
    }
    void Update() {
        // Initial Click
        if (ballMovement.moveState == MovementState.NOT_MOVING) {
            if (Input.GetMouseButtonDown(0)) {
                Vector3 startPos = transform.position;
                lineRenderer.SetPosition(0, startPos); // Start Position where the ball is currently positioned
                lineRenderer.enabled = true; // Shows drag line on click
            }
            // Hold / Drag
            if (Input.GetMouseButton(0)) {
                // ********* Need change this to have a line limit:
                ballMovement.moveState = MovementState.DRAGGING;
                Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
                lineRenderer.SetPosition(1, endPos); // End Position
            }
            // Release
            if (Input.GetMouseButtonUp(0)) {
                lineRenderer.enabled = false; // Hides the drag line once released

                // Adds force to object
                Vector3 inputForce = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
                ballMovement.inputForce = inputForce;
                ballMovement.moveState = MovementState.MOVE;
            }
        }
    }
   
}
