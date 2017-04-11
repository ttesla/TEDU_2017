using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Muzzle yani namlunun oldugu yerden, (prefab icindeki gorunmeyen kup)
/// Tanimli prefab'i (sphere) yaratip, belli bir force ile firlatmaktadir. 
/// Sag, Sol ok tuslari ile saga sola donebilirsiniz.
/// Space ile top atabilirsiniz. 
/// Ileri, geri ok tuslari ile de ileri geri gidebilirsiniz.
/// 
/// Ayrica bu ornekte, obje dondurme, yerel koordinatlara gore ileri, geri gitme
/// gosterilmistir.
/// </summary>
public class ShooterCube : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject Ball;
    public float Velocity;
    public float RotationSpeed;
    public float ShootForce;

	
	void Update ()
    {
        // Saga don
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Sol el kurali
            transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        }

        // Sola don
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Sol el kurali
            transform.Rotate(-Vector3.up, RotationSpeed * Time.deltaTime);
        }

        // Ileri git
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Velocity * Time.deltaTime;
        }

        // Geri git
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += -transform.forward * Velocity * Time.deltaTime;
        }
    }

    // Fizik ile alakali olanlar buraya
    private void FixedUpdate()
    {
        // Shoot!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var ball = GameObject.Instantiate(Ball, Muzzle.position, Quaternion.identity);  // Top yarat
            var ballRigidbody = ball.GetComponent<Rigidbody>();                             // Topun rigidbody'sine eris

            // Muzzle transform kullanimina dikkat!
            ballRigidbody.AddForce(Muzzle.transform.forward * ShootForce, ForceMode.Impulse);
        }
    }
}
