using System;
using UnityEngine;

public class Grid {

    private readonly Guid[] gridSquares;
    public readonly uint WIDTH;
    public readonly uint HEIGHT;

    public Grid(uint width, uint height) {
        this.WIDTH = width;
        this.HEIGHT = height;
        gridSquares = new Guid[width * height];

        for (uint i = 0; i < width * height; i++) {
            gridSquares[i] = Guid.NewGuid();
        }
    }

    public Guid GetGridCoordinante(uint x, uint y) {
        if (x >= this.WIDTH || y >= this.HEIGHT) throw new ArgumentException("Your coordinates are out of bounds.");
        uint gridIndex = (y * this.WIDTH) + x;
        return this.gridSquares[gridIndex];
    }
}
