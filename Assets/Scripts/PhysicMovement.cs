using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity Fizik kullanarak obje hareket ettirme ornegidir.
/// Dogrudan "velocity - hiz"  vererek veya "force - kuvvet" uygulayarak 
/// 2 farkli kullanimi orneklenmistir. 
/// Not: Unity genel fizik ayarlarindan, yer cekimi ivmesi 50.0f yapilmistir.
/// </summary>
public class PhysicMovement : MonoBehaviour
{
    // Public olan degerler editorden ayarlanacaktir
    public float Velocity;
    public float JumpForce;

    private Rigidbody mRigidbody;

    void Start()
    {
        // Objenin fizik degerlerine erismek icin rigidbody component (bilesen) e ihtiyacimiz var. 
        mRigidbody = GetComponent<Rigidbody>();
    }

    // Update() yerine FixedUpdate() kullanildigina dikkat ediniz. 
    // Rigidbody'ye mudahele ederken, komutlarimizi FixedUpdate icerisinde veriyoruz. 
    // Bkz: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    void FixedUpdate()
    {
        // Space'e basarak objeye yukari yonlu "JumpForce" kadar bir kuvvet uyguluyoruz
        // AddForce parametre olarak ForceMode aliyor, onu da degistirerek farklarini inceleyebilirsiniz. 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mRigidbody.AddForce(Vector3.up * JumpForce);
        }


        // Dogrudan Velocity verilen ornekler:

        Vector3 currentVelocity = mRigidbody.velocity;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //mRigidbody.velocity = Vector3.left * Velocity; // Boyle de yapabilirdik ama Y ve Z 'deki mevcut velocity degerini
                                                             // sifirlamis olurduk.

            mRigidbody.velocity = new Vector3(-Velocity, currentVelocity.y, currentVelocity.z);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            mRigidbody.velocity = new Vector3(Velocity, currentVelocity.y, currentVelocity.z);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            mRigidbody.velocity = new Vector3(currentVelocity.x, currentVelocity.y, Velocity);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            mRigidbody.velocity = new Vector3(currentVelocity.x, currentVelocity.y, -Velocity);
        }
    }
}
