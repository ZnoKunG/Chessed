using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    Board board;

    public int boardSize = 8;
    public Color lightSquareColor;
    public Color darkSquareColor;
    public Material squareTextureMaterial;
    private void Awake() {
        board = new Board(boardSize, Vector3.zero, squareTextureMaterial, lightSquareColor, darkSquareColor);
        board.DrawBoard();
    }
}
