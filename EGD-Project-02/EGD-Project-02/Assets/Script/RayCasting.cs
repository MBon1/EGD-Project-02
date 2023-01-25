using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] PlayerController playerController;
    [SerializeField] RayCastingUI rayCastUI;

    [SerializeField] UnlockLock unlock;

    [SerializeField] AudioSource sfx;
    public AudioClip correct;
    public AudioClip wrong;

    public string targetMapName = "key";

    // Start is called before the first frame update
    void Start()
    {
        camera.orthographic = false;
        playerController.canMove = true;
        rayCastUI.EnableRayCastUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) ||
            (Input.GetKeyDown(KeyCode.Escape) && camera.orthographic))
        {
            ChangePerspective();
        }
        else if (Input.GetButtonDown("Fire1") && camera.orthographic)
        {
            if (CheckScreenPoint())
            {
                Debug.Log("FOUND ITEM");
                ChangeSFX(correct);
                if (targetMapName == "key")
                {
                    targetMapName = "door";
                }
                else
                {
                    if (targetMapName == "door")
                    {
                        targetMapName = "";
                        StartCoroutine(unlock.UnlockDoor());
                    }
                }
                ChangePerspective();
            }
            else
            {
                ChangeSFX(wrong);
                Debug.Log("NO ITEM");
            }
        }
    }

    void ChangePerspective()
    {
        camera.orthographic = !camera.orthographic;
        playerController.canMove = !playerController.canMove;
        rayCastUI.EnableRayCastUI(camera.orthographic);
    }

    public bool CheckScreenPoint()
    {
        if (!GlobalVars.maps.ContainsKey(targetMapName))
        {
            return false;
        }

        Material correctMat = null;
        List<Color> wrongMats = new List<Color>();

        for (int i = 0; i < GlobalVars.rows; i++)
        {
            for (int j = 0; j < GlobalVars.columns; j++)
            {
                if (GlobalVars.maps[targetMapName][i][j] == GlobalVars.noPointChar)
                {
                    continue;
                }

                RaycastHit hitInfo;
                //bool hit = Physics.Linecast(castPoint, castPoint + camera.transform.forward * 100, out hitInfo);
                //bool hit = Physics.Raycast(castPoint, camera.transform.forward, out hitInfo, camera.farClipPlane, LayerMask.NameToLayer("Player"));
                Ray ray = camera.ScreenPointToRay(rayCastUI.rayPoints[i][j].transform.position);
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.black);

                bool hit = Physics.Raycast(ray, out hitInfo, camera.farClipPlane, LayerMask.NameToLayer("Terrain"));

                Material material = null;
                if (hit)
                {
                    material = GetMaterialOffObject(hitInfo.transform.gameObject);
                }

                if (GlobalVars.maps[targetMapName][i][j] == GlobalVars.boarderChar)
                {
                    if (hit)
                    {
                        //hitInfo.transform.gameObject
                        if (material != null && !wrongMats.Contains(material.color))
                        {
                            if (correctMat != null && material.color == correctMat.color)
                            {
                                return false;
                            }

                            wrongMats.Add(material.color);
                        }
                    }
                }
                else
                {
                    if (!hit)
                    {
                        return false;
                    }

                    if (correctMat == null)
                    {
                        correctMat = material;
                    }
                    else
                    {
                        if (correctMat.color != material.color)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        if (correctMat == null || (correctMat != null && wrongMats.Contains(correctMat.color)))
        {
            return false;
        }

        return true;
    }

    private Material GetMaterialOffObject(GameObject g)
    {
        Renderer r = g.GetComponent<Renderer>();
        if (r == null)
        {
            return null;
        }

        return r.material;
    }
    public void ChangeSFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
