using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public int[,] BOARD = new int[20, 10] {
        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
        { 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
    List<int[,]> BLOCK_LIST = new List<int[,]>();
    int xx;
    int yy;
    int block_length;
    int[,] block;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        
        int[,] Block1 = new int[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        int[,] Block2 = new int[,] { { 0, 2, 2}, { 0, 2, 2}, { 0, 0, 0}};
        int[,] Block3 = new int[,] { { 0, 3, 0 }, { 3, 3, 3 }, { 0, 0, 0 } };
        int[,] Block4 = new int[,] { { 4, 0, 0 }, { 4, 4, 4 }, { 0, 0, 0 } };
        int[,] Block5 = new int[,] { { 0, 0, 5 }, { 5, 5, 5 }, { 0, 0, 0 } };
        int[,] Block6 = new int[,] { { 0, 6, 6 }, { 6, 6, 0 }, { 0, 0, 0 } };
        int[,] Block7 = new int[,] { { 7, 7, 0 }, { 0, 7, 7 }, { 0, 0, 0 } };
        BLOCK_LIST.Add(Block1);
        BLOCK_LIST.Add(Block2);
        BLOCK_LIST.Add(Block3);
        BLOCK_LIST.Add(Block4);
        BLOCK_LIST.Add(Block5);
        BLOCK_LIST.Add(Block6);
        BLOCK_LIST.Add(Block7);
        regen();
    }
    void reset()
    {
        BOARD = new int[20, 10] {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
    }
    void regen()
    {
        block = BLOCK_LIST[Random.Range(0,7)];
        xx = 3;
        yy = 0;
        block_length = (int)(Mathf.Sqrt(block.Length));

    }
    void denote()
    {
        for (int y = 0; y < block_length; y++)
        {
            for (int x = 0; x < block_length; x++)
            {
                if (x + xx < 0 || x + xx > 9)
                {
                    continue;
                }
                if ((block[y,x] != 0) && (BOARD[y + yy, x + xx] == 0))
                {
                    BOARD[y + yy, x + xx] = block[y, x];
                }
            }
        }
    }
    void spin()
    {
        for (int y = 0; y < block_length; y++)
        {
            for (int x = 0; x < block_length; x++)
            {
                if (x + xx < 0 || x + xx > 9)
                {
                    continue;
                }
                if ((BOARD[y + yy, x + xx] == block[y, x]) && (block[y, x] != 0))
                {
                    BOARD[y + yy, x + xx] = 0;
                }
            }
        }
        bool possible = true;
        int[,] new_block = new int[block_length, block_length];
        for (int y = 0; y < block_length; y++)
        {
            for (int x = 0; x < block_length; x++)
            {
                new_block[x, y] = block[block_length-y-1, x];
            }
        }
        for (int y = 0; y < block_length; y++)
        {
            if (possible == false)
            {
                break;
            }
            for (int x = 0; x < block_length; x++)
            {
                if (new_block[y, x] != 0 && (BOARD[y, x + xx] != 0))
                {

                    possible = false;
                }
                if ((x+xx < 0 || x+xx > 9) && new_block[y, x] != 0)
                {
                    possible = false;
                }
            }
        }
        if (possible)
        {
            block = new_block;
            Debug.Log("n");
        }
        
    }

    void move(int lr)
    {
        bool possible = true;
        for (int y = 0; y < block_length; y++)
        {
            for (int x = 0; x < block_length; x++)
            {
                if (x + xx < 0 || x + xx > 9)
                {
                    continue;
                }
                if ((BOARD[y + yy, x + xx] == block[y, x]) && (block[y,x]!=0))
                {
                    BOARD[y + yy, x + xx] = 0;
                }
            }
        }
        for (int y = 0; y < block_length; y++)
        {
            if (possible==false)
            {
                break;
            }
            for (int x = 0; x < block_length; x++)
            {
                int xxx = x + xx + lr;
                if (block[y, x] != 0 && (BOARD[y,xxx]!=0))
                {
                    
                    possible = false;
                }
                if ((xxx<0|| xxx>9) && block[y, x]!=0)
                {
                    possible = false;
                }
            }
        }

        if (possible)
        {

            xx += lr;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move(-1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            spin();
        }
        denote();
    }

}
