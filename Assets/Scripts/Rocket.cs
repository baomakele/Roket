using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float speed;
    private float fuel;

    public void Accelerate(float amount)
    {
        if (fuel > 0)
        {
            speed += amount;
            fuel--;
        }
    }
}