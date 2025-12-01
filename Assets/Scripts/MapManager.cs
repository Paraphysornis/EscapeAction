using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapchip = new GameObject[6];
    int[,] mapdata = new int[10, 150];

    void Start()
    {
        for (short y = 0; y < 10; y++)
        {
            for (short x = 0; x < 150; x++)
            {
                if (y == 0)
                {
                    mapdata[y, x] = 1;
                }
                else
                {
                    if (y == 1 && Random.Range(0, 100) < 5)
                    {
                        mapdata[y, x] = 3;
                    }
                    else
                    {
                        mapdata[y, x] = 0;
                    }
                }
            }
        }

        for (int i = 1; i < 9; i++)
        {
            int x = 15 * i + Random.Range(0, 15);
            int y = Random.Range(1, 8);
            mapdata[y, x] = 5;
            mapdata[y - 1, x] = 5;
            mapdata[y + 1, x] = 5;
            mapdata[y, x - 1] = 5;
            mapdata[y, x + 1] = 5;
        }

        mapdata[1, 149] = 6;
        int a = 0;
        int b = 8;
        int n = 5;

        do
        {
            for (int i = 0; i < n; i++)
            {
                mapdata[b, a] = 2;
                
                if (Random.Range(0, 100) < 5)
                {
                    mapdata[b + 1, a] = 4;
                }

                a++;
            }

            b = Random.Range(2, 9);
            n = Random.Range(2, 5);
        }
        while (a < 140);

        for (short y = 0; y < 10; y++)
        {
            for (short x = 0; x < 150; x++)
            {
                if (mapdata[y, x] > 0)
                {
                    Instantiate(mapchip[mapdata[y, x] - 1], new Vector3(0.72f * x, 0.72f * y, 0), Quaternion.identity);
                }
            }
        }
    }
}
