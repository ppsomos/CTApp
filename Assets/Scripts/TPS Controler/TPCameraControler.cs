using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCameraControler : MonoBehaviour
{
    [SerializeField] float MouseX, MouseY;

    [SerializeField] float Sencitivety_X, Sencitivety_Y;
    [SerializeField] int min_x=-45;
    [SerializeField] int max_x=45;
    [SerializeField] Transform Pivot;
    [SerializeField] Transform Target;
    private void Start()
    {
        Pivot.transform.rotation=Target.rotation;
    }
    // Start is called before the first frame update
    void Update()
    {
        MouseX -= ControlFreak2.CF2Input.GetAxis("Mouse Y") * Sencitivety_X;
        MouseY += ControlFreak2.CF2Input.GetAxis("Mouse X") * Sencitivety_Y;
        MouseX = Mathf.Clamp(MouseX, min_x, max_x);
        Pivot.transform.LookAt(Target);
        Pivot.transform.rotation = Quaternion.Euler(MouseX, MouseY, 0);
    }
    void LateUpdate()
    {
        transform.position = Target.position;
    }
}
