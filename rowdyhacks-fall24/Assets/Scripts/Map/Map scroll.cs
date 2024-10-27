using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapscroll : MonoBehaviour
{

    Renderer rend;

    [Range(0f, 10f)]
    public float scrollSpeed = 2.0f;
    private float offset;
    private Material mat;


    public bool xAxis;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed)/10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
