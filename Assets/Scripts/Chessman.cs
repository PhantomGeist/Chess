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

    public Sprite black_king, black_queen, black_knight, black_bishop, black_rook, black_pawn;
    public Sprite white_king, white_queen, white_knight, white_bishop, white_rook, white_pawn;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();
        
        if(this.name == "black_king")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_king;
            player = "black";
        }

        if(this.name == "black_queen")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_queen;
            player = "black";
        }

        else if(this.name == "black_knight")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_knight;
            player = "black";
        }

        else if(this.name == "black_bishop")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_bishop;
            player = "black";
        }

        else if(this.name == "black_rook")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_rook;
            player = "black";
        }

        else if(this.name == "black_pawn")
        {
            this.GetComponent<SpriteRenderer>().sprite = black_pawn;
            player = "black";
        }

        if(this.name == "white_king")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_king;
            player = "white";
        }

        else if(this.name == "white_queen")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_queen;
            player = "white";
        }

        else if(this.name == "white_knight")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_knight;
            player = "white";
        }

        else if(this.name == "white_bishop")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_bishop;
            player = "white";
        }

        else if(this.name == "white_rook")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_rook;
            player = "white";
        }

        else if(this.name == "white_pawn")
        {
            this.GetComponent<SpriteRenderer>().sprite = white_pawn;
            player = "white";
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

    public void OnMouseUp()
    {
        if(!controller.GetComponent<Game>().IsGameOver() && 
        controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            DestroyMovePlates();

            InitiateMovePlates();
        }
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        if(this.name == "black_queen" || this.name == "white_queen")
        {
            LineMovePlate(1, 0);
            LineMovePlate(0, 1);
            LineMovePlate(1, 1);
            LineMovePlate(-1, 0);
            LineMovePlate(0, -1);
            LineMovePlate(-1, -1);
            LineMovePlate(-1, 1);
            LineMovePlate(1, -1);
        }

        else if(this.name == "black_knight" || this.name == "white_knight")
        {
            LMovePlate();
        }

        else if(this.name == "black_bishop" || this.name == "white_bishop")
        {
            LineMovePlate(1, 1);
            LineMovePlate(1, -1);
            LineMovePlate(-1, 1);
            LineMovePlate(-1, -1);
        }

        else if(this.name == "black_king" || this.name == "white_king")
        {
            SurroundMovePlate();
        }

        else if(this.name == "black_rook" || this.name == "white_rook")
        {
            LineMovePlate(1, 0);
            LineMovePlate(0, 1);
            LineMovePlate(-1, 0);
            LineMovePlate(0, -1);
        }

        else if(this.name == "black_pawn")
        {
            PawnMovePlate(xBoard, yBoard - 1);
        }

        else if(this.name == "white_pawn")
        {
            PawnMovePlate(xBoard, yBoard + 1);
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<Chessman>().player != player)
        {
            MovePlateAttackSpawn(x, y);
        }
    }

    public void LMovePlate()
    {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void SurroundMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 0);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 0);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x, y))
        {
            GameObject cp = sc.GetPosition(x, y);

            if(cp == null)
            {
                MovePlateSpawn(x, y);
            }

            else if (cp.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void PawnMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x, y))
        {
            if(sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
            }

            if(sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && 
            sc.GetPosition(x + 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x + 1, y);
            }

            if(sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null && 
            sc.GetPosition(x - 1, y).GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x - 1, y);
            }
        }
    }

    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.69f;
        y *= 0.69f;

        x += -2.42f;
        y += -2.42f;

        GameObject mp = Instantiate(movePlate, new Vector3(x,y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 0.69f;
        y *= 0.69f;

        x += -2.42f;
        y += -2.42f;

        GameObject mp = Instantiate(movePlate, new Vector3(x,y, -3.0f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
}

