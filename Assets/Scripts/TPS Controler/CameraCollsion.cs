using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollsion : MonoBehaviour
{
    [SerializeField] float minDis=.3f;
    [SerializeField] float MaxDis=1f;
    [SerializeField] float Smooth;
    [SerializeField] float Distance;
    [SerializeField] LayerMask Collisionlayer;
    Vector3 dollyDir;
    // Start is called before the first frame update
    void Start()
    {
        dollyDir = transform.localPosition.normalized;
        Distance =transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DesireCamPos=transform.parent.TransformPoint(dollyDir*MaxDis);
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, DesireCamPos, out hit, Collisionlayer))
        {
            Distance = Mathf.Clamp(hit.distance, minDis, MaxDis);
        }
        else 
        {
            Distance = MaxDis;
        }
        transform.localPosition=Vector3.Lerp(transform.localPosition,dollyDir*Distance,Smooth*Time.deltaTime);
    }
}
