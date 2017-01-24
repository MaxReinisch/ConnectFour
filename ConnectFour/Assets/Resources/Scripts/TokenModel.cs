using UnityEngine;
using System.Collections;

public class TokenModel : MonoBehaviour {

    Token token;
    public Material mat;

    // Use this for initialization
    public void init(Token t)
    {
        token = t;
        transform.parent = token.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        name = "token model";

        mat = GetComponent<Renderer>().material;
        mat.shader = Shader.Find("Transparent/Diffuse");
        mat.mainTexture = Resources.Load<Texture2D>("Textures/tile");
        mat.color = Color.white;
    }
	
	public void setRed()
    {
        mat.color = Color.red;
    }
    public void setBlue()
    {
        mat.color = Color.blue;
    }


    // Update is called once per frame
    void Update () {
	
	}
}
