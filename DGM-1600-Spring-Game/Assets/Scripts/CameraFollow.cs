using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    public Vector3 targetOffset;
    public float cameraHeight = 12f;
    public float cameraDepth = -4f;
    public float focusSpeed = 1f;

    public GameObject tempTarget;
    public float tempFocusTime = 3f;

 

    void Start()
    {
       

    }

    void LateUpdate()
    {
        if (tempTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position, tempTarget.transform.position + targetOffset, Time.deltaTime * focusSpeed);

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);

        }
        else if (target != null)
        {
            if (target.GetComponent<PlayerOneMovment>() != null)
            {
                PlayerOneMovment player = target.GetComponent<PlayerOneMovment>();

                Vector3 playerTargetPosition = player.transform.position + Vector3.up * cameraHeight + player.transform.forward * cameraDepth;

                transform.position = Vector3.Lerp(transform.position, playerTargetPosition, Time.deltaTime * focusSpeed);

                //
                transform.position = Vector3.Lerp(transform.position, player.transform.position + targetOffset, Time.deltaTime * focusSpeed);
            }
        }
    }

    public void FocusOn (GameObject target)
    {
        tempTarget = target;
        StartCoroutine(FocusOnRoutine());
    }
    private IEnumerator FocusOnRoutine ()
    {
        yield return new WaitForSeconds(tempFocusTime);

        tempTarget = null;
    }
}