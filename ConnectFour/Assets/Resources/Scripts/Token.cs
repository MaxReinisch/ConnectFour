using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour {

    public int realX;
    public int realY;

    public int color;

    public const int EMPTY = 0;
    public const int RED = 1;
    public const int BLUE = 2;

    public Controller controller;
    public TokenModel model;

    public BoxCollider2D collider;


    // Use this for initialization
    public void init(int realX, int realY, Controller controller)
    {
        this.realX = realX;
        this.realY = realY;
        this.controller = controller;
        this.color = EMPTY;


        collider = this.gameObject.AddComponent<BoxCollider2D>();
        collider.size.Set(1f, 1f);
        collider.isTrigger = true;

        //model
        var modelObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
        model = modelObject.AddComponent<TokenModel>();
        model.init(this);
    }

    void OnMouseUp() {
        controller.addToColumn(realX);
        MonoBehaviour.print(this.realX + ", " + this.realY);
      

    }

    public void setColor(int turns)
    {
        if(turns%2 == 0)
        {
            model.setRed();
            color = RED;
        }
        else
        {
            model.setBlue();
            color = BLUE;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
