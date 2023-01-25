using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastingUI : MonoBehaviour
{
    [SerializeField] GameObject[] rows;

    Image[][] rayPoints;

    string mapName = "key";

    /*int r = 0;
    int c = 0;
    float t = 0;*/

    // Start is called before the first frame update
    void Start()
    {
        rayPoints = new Image[GlobalVars.rows][];
        for (int i = 0; i < GlobalVars.rows; i++)
        {
            rayPoints[i] = rows[i].GetComponentsInChildren<Image>();
        }
        ConstructRayCastLayout();
        //t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (c >= GlobalVars.columns)
        {
            c = 0;
            r++;
            r %= GlobalVars.rows;
        }

        rayPoints[r][c].color = Color.white;
        
        if(Time.time - t >= 0.5f)
        {
            rayPoints[r][c].color = Color.black;
            c++;
            t = Time.time;
        }*/
    }

    public void EnableRayCastUI(bool enable)
    {
        this.gameObject.SetActive(enable);
        if (enable)
        {
            ConstructRayCastLayout();
        }
    }

    void ConstructRayCastLayout()
    {
        if (!GlobalVars.maps.ContainsKey(mapName))
        {
            return;
        }

        for (int i = 0; i < GlobalVars.rows; i++)
        {
            for (int j = 0; j < GlobalVars.columns; j++)
            {
                if (GlobalVars.maps[mapName][i][j] == GlobalVars.boarderChar)
                {
                    rayPoints[i][j].color = GlobalVars.rayPointWrongColor;
                }
                else if (GlobalVars.maps[mapName][i][j] == GlobalVars.rayPointChar)
                {
                    rayPoints[i][j].color = GlobalVars.rayPointCorrectColor;
                }
                else
                {
                    rayPoints[i][j].color = GlobalVars.rayPointNoneColor;
                }
            }
        }
    }
}
