using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public Token[,] board;
    public int turn = 0;
	// Use this for initialization
	void Start () {

        board = new Token[7, 7];
        createBoard();
	}
	
    public void addToColumn(int col)
    {
        
        for(int row = 0; row < 7; row++)
        {
            Token token = board[col, row];
            if(token.color == Token.EMPTY)
            {
                token.setColor(turn);
                turn++;
                checkForWin();
                break;
            }
        }
        
    }

    public void checkForWin()
    {
        //TODO
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

	// Update is called once per frame
	void Update () {
	
	}
}
