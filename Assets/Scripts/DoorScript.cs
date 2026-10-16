using UnityEngine;

public class DoorScript : MonoBehaviour
{
    float doorTimer = 0f;
    bool isUp = false;
    float speed = 5;
    public Vector3 offset = new Vector3(0, 3, 0);
    public float timerMax = 4f;

    public bool vertical = true;
    void Start()
    {
        
    }

    void Update()
    {
        doorTimer += Time.deltaTime;
        if (doorTimer >= timerMax)
        {
            if (isUp == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, (transform.position -= offset), speed);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, (transform.position += offset), speed);
            }
            isUp = !isUp;
            doorTimer = 0f;       
        }
    }
    
}
