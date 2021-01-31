using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board_maker : MonoBehaviour
{
    public GameObject can;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                GameObject cell = Instantiate(can, new Vector3(-2.25f + x * 0.5f, 4.75f - y * 0.5f, 0), Quaternion.identity, transform.parent = parent.transform);
                cell.GetComponent<can>().x = x;
                cell.GetComponent<can>().y = y;
            }
        }

    }
}