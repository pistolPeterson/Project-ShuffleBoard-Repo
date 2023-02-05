using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script that renders the drag line to show how much force will be applied to the ball on push.
/// When mouse1 button released, ball will be moved.
/// </summary>
public class DragLine : MonoBehaviour {
    private LineRenderer lineRenderer;
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private Material material;
    [SerializeField] private float startWidth = 20.0f;
    [SerializeField] private float endWidth = 1.0f;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    void Start()    {
        // Gets Components and adds if object does not have them.
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null) {
            rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        }
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
    }
    void Update() {
        // Initial Click
        if (Input.GetMouseButtonDown(0)) {
            Vector3 startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(0, startPos); // Start Position
            lineRenderer.SetPosition(1, startPos); // End Position
            lineRenderer.enabled = true; // Shows drag line on click
        }
        // Hold / Drag
        if (Input.GetMouseButton(0)) {
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
            lineRenderer.SetPosition(1, endPos); // End Position
        }
        // Release
        if (Input.GetMouseButtonUp(0)) {
            lineRenderer.enabled = false; // Hides the drag line once released

            // Adds force to object
            // If object movement is sup to be in another place, remove these lines:
            Vector3 inputForce = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
            rigidbody2D.AddForce(inputForce, ForceMode2D.Impulse);
        }
    }
   
}
