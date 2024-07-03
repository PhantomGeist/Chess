using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite black_queen, black_knight, black_bishop, black_rook, black_pawn;
    public Sprite white_queen, white_knight, white_bishop, white_rook, white_pawn;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();
        
        if(this.name == "black_queen")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_queen;
        }

        else if(this.name == "black_knight")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_knight;
        }

        else if(this.name == "black_bishop")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_bishop;
        }

        else if(this.name == "black_rook")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_rook;
        }

        else if(this.name == "black_pawn")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_pawn;
        }

        else if(this.name == "white_queen")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_queen;
        }

        else if(this.name == "white_knight")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_knight;
        }

        else if(this.name == "white_bishop")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_bishop;
        }

        else if(this.name == "white_rook")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_rook;
        }

        else if(this.name == "white_pawn")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_pawn;
        }

    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.69f;
        y *= 0.69f;

        x += -2.42f;
        y += -2.42f;

        this.transform.position =new Vector3(x,y,-1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }
}
