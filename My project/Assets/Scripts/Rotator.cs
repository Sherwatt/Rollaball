using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Rotate allows for the cube to rotate upon it's position, the deltaTime part ensures it does it smoothly
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
