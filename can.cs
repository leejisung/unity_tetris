using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    public int y;
    public int x;
    public Sprite[] sprite_array;
    //blank, sky, yellow, red, green, blue, orange, purple
    public Sprite my_sprite;

    private SpriteRenderer sp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = sprite_array[GameManager.Instance.BOARD[y, x]];

    }
}
