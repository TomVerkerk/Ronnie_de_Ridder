using UnityEngine;
using System.Collections;
using System;

public class StringToModels : MonoBehaviour {
    [SerializeField]
    string[] Text;
    [SerializeField]
    Vector2 letterSize = new Vector2(1.2f,3f);
	void Start () 
    {
        Vector3 offSet;
        Vector3 toAdded;
        for (int i = 0; i < Text.Length; i++)
        {
            offSet = new Vector3(0, i * letterSize.y);
            for (int j = 0; j < Text[i].Length; j++)
            {
                toAdded = getOffSet(i, Text[i][j]);
                offSet += toAdded / 2f;
                SpawnLetter(Text[i][j],offSet);
                offSet += toAdded / 2f;
            }
        }

        Orbital.DarkHoleEffects voidhole = GetComponent<Orbital.DarkHoleEffects>();
        voidhole.enabled = true;
	}

    void SpawnLetter(char l, Vector3 pos)
    {
        l = char.ToUpper(l);
        if (l != ' ' && l != null) 
        {
            GameObject let = Instantiate(Resources.Load("Letters/Letter" + l), pos, Quaternion.Euler(new Vector3(0, 180f, 0))) as GameObject;
            let.AddComponent<BoxCollider>();
            let.AddComponent<Rigidbody>();
            let.rigidbody.useGravity = false;
            let.rigidbody.isKinematic = true;
            let.AddComponent<Orbital.Orbit>().mass=10f;
            let.name = " " + l;
            let.transform.parent = transform;
        }
    }

    Vector3 getOffSet(int y, char c)
    {
        c = char.ToUpper(c);
        Vector3 output = Vector3.zero;
        switch (c)
        {
            case'A':
                output = new Vector3(letterSize.x *  1.1f,0f);
                break;
            case 'B':
                output = new Vector3(letterSize.x * 1.2f,0f);
                break;
            case 'W':
                output = new Vector3(letterSize.x * 1.8f, 0f);
                break;
            case 'M':
                output = new Vector3(letterSize.x * 1.8f, 0f);
                break;
            case 'J':
                output = new Vector3(letterSize.x * 0.7f, 0f);
                break;
            case 'I':
                output = new Vector3(letterSize.x * 0.7f, 0f);
                break;
            case 'K':
                output = new Vector3(letterSize.x * 1.1f, 0f);
                break;
            default:
                output = new Vector3(letterSize.x,0f);
                break;
        }
        return output;
    }
}
