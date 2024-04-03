using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] Camera uiCamera = null;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Cube cube = Pool.Instance.GetObject();

                cube.transform.position = hit.point + new Vector3(0, cube.transform.localScale.y * 0.5f, 0);

                cube.ResetAfterTime();
            }
            else
            {

            }
        }
    }
}
