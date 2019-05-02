using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTreadSpline : MonoBehaviour
{

    Vector3 GetPoint(Vector3[] points, float t)
    {
        Vector3 a = Vector3.Lerp(points[0], points[1], t);
        Vector3 b = Vector3.Lerp(points[1], points[2], t);
        Vector3 c = Vector3.Lerp(points[2], points[2], t);
        Vector3 d = Vector3.Lerp(a, b, t);
        Vector3 e = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(d, e, t);
    }

    Vector3 GetPointV2(Vector3[] points, float t)
    {
        float omt = 1f - t;
        float omt2 = omt * omt;
        float t2 = t * t;

        return
        points[0] * (omt2 * omt) +
        points[1] * (3f * omt2 * t) +
        points[2] * (3f * omt * t2) +
        points[3] * (t2 * t);
    }

    Vector3 GetTangent(Vector3[] points, float t)
    {
        float omt = 1f - t;
        float omt2 = omt * omt;
        float t2 = t * t;

        Vector3 tangent =
        points[0] * (-omt2) +
        points[1] * (3 * omt2 - 2 * omt) +
        points[2] * (-3 * t2 + 2 * t) +
        points[3] * (t2);

        return tangent.normalized;
    }

    Vector3 GetNormal2D(Vector3[] points, float t)
    {
        Vector3 tng = GetTangent(points, t);
        return new Vector3(-tng.y, tng.x, 0f);
    }

    Quaternion GetOrientation2D(Vector3[] points, float t)
    {
        Vector3 tangent = GetTangent(points, t);
        Vector3 normal = GetNormal2D(points, t);
        return Quaternion.LookRotation(tangent, normal);
    }


}
