using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public Token[,] board;
    public int turn = 0;
    public string textbox = "Red player turn";

    public const int BOARD_HEIGHT = 7;
    public const int BOARD_WIDTH= 7;

    public bool GAMEOVER = false;
    // Use this for initialization
    void Start () {

        board = new Token[BOARD_WIDTH, BOARD_HEIGHT];
        createBoard();

	}
	
    public void addToColumn(int col)
    {
        if (!GAMEOVER) {
            for (int row = 0; row < BOARD_HEIGHT; row++)
            {
                Token token = board[col, row];
                if (token.color == Token.EMPTY)
                {
                    token.setColor(turn);
                    checkForWin(col, row);
                    nextTurn();
                    break;
                }
            }
        }
        
    }

    public int getTurn()
    {
        if (turn % 2 == 0)
        {
            return Token.RED;
        }
        else
        {
            return Token.BLUE;
        }
    }

    public void nextTurn()
    {
        if (!GAMEOVER) { 
            if (getTurn() == Token.RED)
            {
                textbox = "Blue player turn";
            }
            else
            {
                textbox = "Red player turn";
            }
            turn++;
        }
    }

    public void checkForWin(int x, int y)
    {
        GAMEOVER = checkCol(x)||checkRow(y)||checkDiag1(x, y)||checkDiag2(x, y);
    }

    public bool checkCol(int x)
    {
        int currentTurn = getTurn();
        int seen = 0;
        for (int y = 0; y < 7; y++)
        {
            if (board[x,y].color == currentTurn)
            {
                seen++;
                print(seen);
                if (seen == 4)
                {
                   
                    textbox = "Game over!";
                    return true;

                }
            }
            else
            {
                seen = 0;
            }
        }
        return false;
    }

    public bool checkRow(int y)
    {
        int currentTurn = getTurn();
        int seen = 0;
        for (int x = 0; x < 7; x++)
        {
            if (board[x, y].color == currentTurn)
            {
                seen++;
                print(seen);
                if (seen == 4)
                {

                    textbox = "Game over!";
                    return true;

                }
            }
            else
            {
                seen = 0;
            }
        }
        return false;
    }

    public bool checkDiag1(int x, int y)
    {
        int currX = x;
        int currY = y;
        while(currX>0 && currY > 0)
        {
            currY--;
            currX--;
        }
        int currentTurn = getTurn();
        int seen = 0;
        while(currX < BOARD_WIDTH && currY < BOARD_HEIGHT)
        {
            if (board[currX, currY].color == currentTurn)
            {
                seen++;
                if (seen == 4)
                {
                    textbox = "Game over!";
                    return true;
                }
            }
            else
            {
                seen = 0;
            }
            currY++;
            currX++;
        }
        return false;
    }

    public bool checkDiag2(int x, int y)
    {
        int currX = x;
        int currY = y;
        while (currX < BOARD_WIDTH-1 && currY > 0)
        {
            currY--;
            currX++;
        }
        int currentTurn = getTurn();
        int seen = 0;
        while (currX >= 0 && currY < BOARD_HEIGHT)
        {
            if (board[currX, currY].color == currentTurn)
            {
                seen++;
                if (seen == 4)
                {
                    textbox = "Game over!";
                    return true;
                }
            }
            else
            {
                seen = 0;
            }
            currY++;
            currX--;
        }
        return false;
    }

    public void createBoard()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j< 7; j++)
            {
                board[i,j] = placeTile(i, j);
            }
        }
    }

    Token placeTile(int x, int y)
    {
        GameObject tokeneObject = new GameObject();
        Token token = tokeneObject.AddComponent<Token>();
        token.transform.position = new Vector2(x - 3, y - 3);
        token.init(x, y, this);
        return token;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2 - 50, 30, 100, 20), textbox);
        if(GUI.Button(new Rect(Screen.width - 400, Screen.height / 2, 100, 20), "Reset"))
        {
            SceneManager.LoadScene(0);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
