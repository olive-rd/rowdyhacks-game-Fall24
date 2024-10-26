[System.Serializable]
public struct CarData
{
    public float Velocity;
    public float MaxVelocity;
    public float Acceleration;

    // Constructor to initialize the car data
    public CarData(float velocity, float maxVelocity, float acceleration)
    {
        Velocity = velocity;
        MaxVelocity = maxVelocity;
        Acceleration = acceleration;
    }
    
}
