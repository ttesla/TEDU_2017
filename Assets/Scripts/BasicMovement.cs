using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fizik kullanmadan sadece transform.position degistirerek
/// hareket ettirme ornegidir. 
/// </summary>
public class BasicMovement : MonoBehaviour
{
    // Velocity degeri editorden veriliyor
    public float Velocity;
	
	// Update is called once per frame
	void Update ()
    {
        // Sol, sag, yukari ve asagi tuslari ile World coordinatlara gore bu Script'in bagli oldugu objeyi (gameObject) hareket ettiriyoruz. 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * Velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * Velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Velocity * Time.deltaTime;
        }
    }
}
