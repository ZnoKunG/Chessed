using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Board
{
    Grid<SquareNode> grid;
    Vector3 originPosition;
    Color lightSquareColor;
    Color darkSquareColor;
    Material squareTextureMaterial;

    GameObject board;

    public Board(int boardSize, Vector3 originPosition, Material squareTextureMaterial, Color lightSquareColor, Color darkSquareColor) {
        board = new GameObject("Board");
        grid = new Grid<SquareNode>(8, 8, (float)boardSize / 8, this.originPosition, (Grid<SquareNode> g, int x, int y) => new SquareNode(g, x, y));
        this.squareTextureMaterial = squareTextureMaterial;
        this.lightSquareColor = lightSquareColor;
        this.darkSquareColor = darkSquareColor;
        Debug.Log(grid.GetGridCenterPosition());
    }

    public void DrawBoard() {
        for (int x = 0; x < 8; x++) {
            for (int y = 0; y < 8; y++) {
                SquareNode square = grid.GetGridObject(x, y);
                square.Draw(squareTextureMaterial, lightSquareColor, darkSquareColor);
            }
        }
    }
}
