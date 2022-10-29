using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class EnemySee : MonoBehaviour
 {
    
    public float rotationSpeed;
    public float visionDistance;
    public LineRenderer LineOfSight;

     private void LineOfSight()
    {
        LineOfSight.SetPostition(0, transform.position);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

       RaycastHit2D hitInfo = Raycast2D.Raycast(transform.position, transform.right, visionDistance);

       if(hitInfo.collider != null)
       {
        Debug.DrawLine(transform.position, hitInfo.points, Color.blue);
        LineOfSight.SetPosition(1, hitInfo.point);
        LineOfSight.startColor = Color.blue;
        LineOfSight.endColor = Color.blue;
       }   
       
       
       else
       {
        Debug.DrawLine(transform.position + transform.right * visionDistance, Color.gray);
        LineOfSight.SetPosition(1, transform.position + transform.right * visionDistance);
        LineOfSight.startColor = Color.gray;
        LineOfSight.endColor = Color.gray;
       }
       
     

    }

    public class FollowEnemy : MonoBehavior
  {
       public float speed;
       public Transform target;
       public float minimumDistance;
    
   
   private void Follow()
   {
    if(Vector2.Distance(transform.position, target.position) > minimumDistance)
    {
     transform.position = Vector2.MoveTowards(transform.position, target.position,speed * Time.deltaTime);
    }
   }
  }


   public class PatrolEnemy : MonoBehaviour
  {
   public float speed;
   public Transform[] patrolPoints;
   public float waitTime;
   int currentPointIndex;

   bool once;


   private void Patrol()
   {
    if (transform.position != patrolPoints[currentPointIndex].position)
    {
     transform.position = Vector2.MoveTowards(transform.postition, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

    }
     else
     {
        if (once == false)
        {
            once = true;
        StartCoroutine(Wait());
        }
     }

      IEnumerator Wait()
     {
        yield return new WaitForSeconds(waitTime);
        if(currentPointIndex + 1 < patrolpoints.Lenght)
        {
          currentPointIndex++;
        }
        else
        {
           currentPointIndex = 0;
        }
        once = false;
        
     }

   }

  } 
 }   


