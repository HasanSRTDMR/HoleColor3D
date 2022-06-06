using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] PolygonCollider2D holeCollider;
    [SerializeField] PolygonCollider2D groundCollider;
    [SerializeField] MeshCollider meshCollider;
    [SerializeField] float initialScale = 0.5f;
    Mesh mesh;

    private void FixedUpdate()
    {
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
            holeCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            holeCollider.transform.localScale = transform.localScale * initialScale;
            MakeHole2D();
            Make3DMeshColider();
        }
    }
    void MakeHole2D()
    {
        Vector2[] pointPositions = holeCollider.GetPath(0);//Hole poligon vectors, 0 index
        for (int i = 0; i < pointPositions.Length; i++)
        {
            pointPositions[i] = holeCollider.transform.TransformPoint(pointPositions[i]);//Transforms position from local space to world space
        }
        groundCollider.pathCount = 2;
        groundCollider.SetPath(1, pointPositions);
    }
    void Make3DMeshColider()
    {
        if (mesh != null)
            Destroy(mesh);
        mesh = groundCollider.CreateMesh(true, true);
        meshCollider.sharedMesh = mesh;
    }


}
