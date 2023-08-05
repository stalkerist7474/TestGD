using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Walk,
        Run
    }

    public MovementType Type;
    public MovementPath MyPath;
    public float speed = 1;
    
    public float maxDistance = 0.1f;

    private IEnumerator<Transform> pointInPath;

    private void Start()
    {
        if (MyPath == null)
        {
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    private void Update()
    {
        if(pointInPath == null || pointInPath.Current == null)
        {
            return;
        }
        if(Type == MovementType.Walk)
        {
            speed = 1;
           transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, speed * Time.deltaTime);
        }
        else if (Type == MovementType.Run)
        {
            speed = 2;
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, speed * Time.deltaTime);
            Debug.Log("RUN");
        }


        Vector3 newDir = Vector3.RotateTowards(transform.forward, (pointInPath.Current.position - transform.position), 1, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);


        var distancrSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if(distancrSqure < maxDistance)
        {
            pointInPath.MoveNext();
        }
    }
}
