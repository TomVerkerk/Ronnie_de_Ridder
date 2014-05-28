using UnityEngine;
using System.Collections;

public class WallCollider : MonoBehaviour {

	public float fadeSpeed;
	private bool fading = false;
	private Color customColor;
	private Color emptyColor;

	// Use this for initialization
	void Start () {
		customColor.r = 1;
		customColor.g = 2;
		customColor.b = 4;
		customColor.a = 0.1f;
		//emptyColor = customColor;
		emptyColor.a = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(fading == true)
		{
			Hit();
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Moveable")
		{
			renderer.material.SetColor("_Color",customColor);
			fading = true;
		}
	}

	void Hit()
	{
		renderer.material.color = Color.Lerp(renderer.material.color,emptyColor, fadeSpeed * Time.deltaTime);
		if(renderer.material.color.a < 0.01f)
		{
			renderer.material.color = emptyColor;
			fading = false;
		}
	}
}
