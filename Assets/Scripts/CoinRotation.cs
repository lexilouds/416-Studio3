using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 85f;
    
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
