using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public int movmentDir = 1, moveTo = 0;
    public Transform[] PathElements;
    public bool isStartPoint, isEndPoint;
    public bool isGuestPath;

    public void OnDrawGizmos()
    {
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for (int i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }
    }
    public IEnumerator<Transform>GetNextPathPoitn()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[moveTo];
            if (PathElements.Length == 1)
            {
                continue;
            }
            if (moveTo <= 0)
            {
                movmentDir = 1;
                isStartPoint = true;
                isEndPoint = false;
            }
            else if (moveTo >= PathElements.Length - 1)
            {
                movmentDir = -1;
                isStartPoint = false;
                isEndPoint = true;
            }
            moveTo = moveTo + movmentDir;
        }
    }
}
