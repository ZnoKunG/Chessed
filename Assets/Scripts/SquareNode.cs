using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareNode
{
    public int x;
    public int y;
    Grid<SquareNode> grid;

    // draw mesh
    Mesh mesh;
    GameObject squareObject;
    public SquareNode(Grid<SquareNode> grid, int x, int y) {
        this.x = x;
        this.y = y;
        this.grid = grid;
        mesh = new Mesh();
        squareObject = new GameObject($"Square {x},{y}", typeof(MeshRenderer), typeof(MeshFilter));
        squareObject.transform.parent = GameObject.Find("Board").transform;
        squareObject.transform.position = GetCenterPosition();
        squareObject.GetComponent<MeshFilter>().mesh = mesh;
    }

    public Vector3 GetCenterPosition() {
        return grid.GetCenterWorldPosition(x, y);
    }

    public Vector3 GetPosition() {
        return grid.GetWorldPosition(x, y);
    }

    public void Draw(Material material, Color lightColor, Color darkColor) {
        Vector3 pos = GetPosition();

        Vector3[] vertices = new Vector3[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(pos.x, pos.y);
        vertices[1] = new Vector3(pos.x, pos.y + 2 * grid.GetCellSize());
        vertices[2] = new Vector3(pos.x + 2 * grid.GetCellSize(), pos.y + 2 * grid.GetCellSize());
        vertices[3] = new Vector3(pos.x + 2 * grid.GetCellSize(), pos.y);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        MeshRenderer squareRenderer = squareObject.GetComponent<MeshRenderer>();
        squareRenderer.material = material;
        if ((x + y) % 2 == 0) {
            squareRenderer.material.color = darkColor;
        } else {
            squareRenderer.material.color = lightColor;
        }
    }
}
