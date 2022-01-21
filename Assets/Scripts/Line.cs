using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCol2D;

    [SerializeField] private List<Vector2> points;

    [SerializeField] private float minDistance = .1f;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCol2D = GetComponent<EdgeCollider2D>();
    }

    public void UpdateLine(Vector2 mousePos)
    {
        if (points == null || points.Count == 0)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }
        
        // Check if the mouse has enough for us to insert to a new point
        // If it has: Insert point at mouse position
        if (Vector2.Distance(points.Last(), mousePos) > minDistance)
            SetPoint(mousePos);
    }

    public void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
            edgeCol2D.points = points.ToArray();
    }

} // class
