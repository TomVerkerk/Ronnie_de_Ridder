using UnityEngine;
using System.Collections;
using System;

public class StringToModels : MonoBehaviour
{
    [SerializeField]
    string[] Text;
    [SerializeField]
    float[] TextScale;
    [SerializeField]
    Vector2 letterSize = new Vector2(1.55f, 3f);
    [SerializeField]
    private Orbital.DarkHoleEffects voidhole;
    void Start()
    {
        // if(Text.Length!=TextScale.Length)
        //      TextScale=new float[Text.Length];

        Vector3 offSet;
        Vector3 toAdded;
        float yOffSet = 0f;
        int li = Text.Length;
        for (int i = 0; i < li; i++)
        {
            if (i < TextScale.Length)
                yOffSet -= letterSize.y * TextScale[i];
            else
                yOffSet -= letterSize.y;

            offSet = new Vector3(0f, 0f, yOffSet);
            int lj = Text[i].Length;
            for (int j = 0; j < lj; j++)
            {
                toAdded = getOffSet(Text[i][j], TextScale[i]);
                offSet += toAdded / 2f;
                SpawnLetter(Text[i][j], offSet, TextScale[i]);
                offSet += toAdded / 2f;
            }
        }
        if (voidhole == null)
            voidhole = GetComponent<Orbital.DarkHoleEffects>();
        if (voidhole != null)
            voidhole.enabled = true;
        Destroy(this);
    }

    void SpawnLetter(char l, Vector3 pos, float scale = 1f)
    {
        if (scale == 0)
            scale = 1f;
        l = char.ToUpper(l);
        if (l != ' ')
        {
            GameObject let = Instantiate(Resources.Load("Letters/Letter" + l), Vector3.zero, Quaternion.Euler(new Vector3(-90f, 180f, 0))) as GameObject;
            let.AddComponent<BoxCollider>();
            let.AddComponent<Rigidbody>();
            let.rigidbody.useGravity = false;
            let.rigidbody.isKinematic = true;
            let.AddComponent<Orbital.Orbit>().mass = 10f;
            let.GetComponent<Orbital.Orbit>().parentobj = voidhole;
            let.name = " " + l;
            let.transform.parent = transform;
            let.transform.localPosition = pos;
            let.transform.localScale = let.transform.localScale * scale;
        }
    }

    Vector3 getOffSet(char c, float scale = 1f)
    {
        if (scale == 0)
        {
            scale = 1;
        }
        c = char.ToUpper(c);
        Vector3 output = Vector3.zero;
        switch (c)
        {
            case 'A':
                output = new Vector3(letterSize.x * 1.1f, 0f);
                break;
            case 'B':
                output = new Vector3(letterSize.x * 1.2f, 0f);
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
            case 'C':
                output = new Vector3(letterSize.x * 1.1f, 0f);
                break;
            case 'O':
                output = new Vector3(letterSize.x * 1.1f, 0f);
                break;
            default:
                output = new Vector3(letterSize.x, 0f);
                break;
        }
        output = output * scale;
        return output;
    }
}
