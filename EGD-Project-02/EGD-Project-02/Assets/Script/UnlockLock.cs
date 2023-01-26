using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLock : MonoBehaviour
{
    [SerializeField] Vector3 unlockedPosition = new Vector3(-6, 0, 0);
    [SerializeField] float unlockAnimDuration = 0.5f;
    [SerializeField] string destinationScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UnlockDoor()
    {
        Vector3 initPos = this.transform.localPosition;
        float elapsedTimed = 0;

        while (elapsedTimed < unlockAnimDuration)
        {
            transform.localPosition = Vector3.Lerp(initPos, unlockedPosition, (elapsedTimed / unlockAnimDuration));
            elapsedTimed += Time.deltaTime;
            yield return null;
        }

        elapsedTimed = 0;
        while (elapsedTimed < unlockAnimDuration / 2.0f)
        {
            elapsedTimed += Time.deltaTime;
            yield return null;
        }

        SceneController.LoadScene(destinationScene);
    }
}
