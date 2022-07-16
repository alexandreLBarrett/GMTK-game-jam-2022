using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiceRotator : MonoBehaviour
{
    bool rotating;

    public const float animationTime = 0.5f;
    public new Camera camera;
    public DiceMap dice;

    void Start()
    {
        Debug.Assert(dice != null);
        //dice.facesNormals = GetComponent<MeshFilter>().mesh.normals.Distinct().ToArray();

        transform.LookAt(camera.transform.position);
        RotateToFace(0, false);
    }

    void Update()
    {
        if (!rotating && Input.GetMouseButtonDown(1))
        {
            RotateToFace(Random.Range(0, 6));
        }
    }
    public void RotateToFace(int faceId, bool animate = true)
    {
        if (rotating)
            return;

        Vector3 face = dice.facesNormals[faceId];
        Vector3 cameraPosition = camera.transform.position;

        Vector3 normalPosition = transform.TransformPoint(face);
        Vector3 thisPosition = transform.position;

        Vector3 angleBetweenThisAndCam = Vector3.Normalize(thisPosition - cameraPosition);
        Vector3 angleBetweenThisAndNormal = Vector3.Normalize(thisPosition - normalPosition);

        Vector3 axisOfRotation = Vector3.Cross(angleBetweenThisAndNormal, angleBetweenThisAndCam);
        var angle = Vector3.Angle(angleBetweenThisAndNormal, angleBetweenThisAndCam);

        if (axisOfRotation == Vector3.zero)
            axisOfRotation = Vector3.ProjectOnPlane(Vector3.back, angleBetweenThisAndNormal);

        if (animate)
            StartCoroutine(Rotate(axisOfRotation, angle, animationTime));
        else
            transform.Rotate(axisOfRotation, angle);
    }

    private IEnumerator Rotate(Vector3 axis, float angle, float duration)
    {
        rotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.AngleAxis(angle, axis) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        transform.rotation = endRotation;
        rotating = false;
    }

    private void OnDrawGizmos()
    {
        var normals = dice.facesNormals; // GetComponent<MeshFilter>().sharedMesh.normals;

        for (var i = 0; i < normals.Length; i++)
        {
            Vector3 normalPt = transform.TransformPoint(normals[i]);
            Gizmos.DrawLine(transform.position, normalPt);
        }
    }
}
