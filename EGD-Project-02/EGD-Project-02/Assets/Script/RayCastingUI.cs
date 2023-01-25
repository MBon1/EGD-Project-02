using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class RayCastingUI : MonoBehaviour
{
    [SerializeField] RayCasting casting;
    [SerializeField] GameObject[] rows;
    [SerializeField] Sprite oSprite;
    [SerializeField] Sprite xSprite;


    [SerializeField] GameObject nextTarget;
    [SerializeField] Image nextTargetIcon;
    [SerializeField] Sprite keySprite;
    [SerializeField] Sprite doorSprite;

    public Image[][] rayPoints { get; private set; }

    void Awake()
    {
        rayPoints = new Image[GlobalVars.rows][];
        for (int i = 0; i < GlobalVars.rows; i++)
        {
            rayPoints[i] = rows[i].GetComponentsInChildren<Image>();
        }
        ConstructRayCastLayout();
    }

    public void EnableRayCastUI(bool enable)
    {
        this.gameObject.SetActive(enable);
        if (enable)
        {
            ConstructRayCastLayout();
        }
        ShowTarget(!enable);
    }

    void ConstructRayCastLayout()
    {
        string mapName = casting.targetMapName;
        char[][] map;
        if (!GlobalVars.maps.ContainsKey(mapName))
        {
            //mapName = "template";
            map = GlobalVars.mapTemplate;
        }
        else
        {
            map = GlobalVars.maps[mapName];
        }

        for (int i = 0; i < GlobalVars.rows; i++)
        {
            for (int j = 0; j < GlobalVars.columns; j++)
            {
                if (map[i][j] == GlobalVars.boarderChar)
                {
                    rayPoints[i][j].sprite = xSprite;
                    rayPoints[i][j].color = GlobalVars.rayPointWrongColor;
                }
                else if (map[i][j] == GlobalVars.rayPointChar)
                {
                    rayPoints[i][j].sprite = oSprite;
                    rayPoints[i][j].color = GlobalVars.rayPointCorrectColor;
                }
                else
                {
                    rayPoints[i][j].color = GlobalVars.rayPointNoneColor;
                }
            }
        }
    }

    void ShowTarget(bool enabled)
    {
        nextTarget.SetActive(enabled);
        if (enabled)
        {
            if (casting.targetMapName == "key")
            {
                nextTargetIcon.sprite = keySprite;
            }
            else if (casting.targetMapName == "door")
            {
                nextTargetIcon.sprite = doorSprite;
            }
            else
            {
                nextTargetIcon.sprite = null;
                nextTargetIcon.enabled = false;
            }
        }
    }

}
