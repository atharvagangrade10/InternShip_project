using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
namespace RedBall
{
    public class Player : MonoBehaviour
    {
        public float force;
        public float impulsiveForce;
        public bool grounded;
        public float distance;
        public Collider sphereCollider;
        public float extraDownwardForce;
        public float timer = 0;
        public int count = 0;
        public float maxTouchTime;
        public bool debug;
        // Start is called before the first frame update
        void Start()
        {
            sphereCollider = GetComponent<Collider>();
        }

        // Update is called once per frame
        void Update()
        {
            Movements();
            if (count == 1)
            {
                timer += Time.deltaTime;
                if (timer > maxTouchTime)
                {
                    count = 0;
                    timer = 0;
                }
            }

            //print(spColl.bounds.extents.y);
        }
        void Movements()
        {
            grounded = IsGrounded();
            if (transform.GetComponent<Rigidbody>().velocity.x < 10)
            {
                if (CrossPlatformInputManager.GetButton("Right"))
                {
                    transform.GetComponent<Rigidbody>().AddForce(Vector3.right * force);
                }
                else
                {
                    CrossPlatformInputManager.SetButtonUp("Right");
                }
            }
            if (transform.GetComponent<Rigidbody>().velocity.x > -10)
            {
                if (CrossPlatformInputManager.GetButton("Left"))
                {
                    transform.GetComponent<Rigidbody>().AddForce(Vector3.left * force);
                }
                else
                {
                    CrossPlatformInputManager.SetButtonUp("Left");
                }
            }
            if (transform.GetComponent<Rigidbody>().velocity.y < 7)
            {
                if (PlayerHit() && IsGrounded())
                {
                    transform.GetComponent<Rigidbody>().AddForce(Vector3.up * impulsiveForce, ForceMode.Impulse);
                }
            }
            else
            {
                if (!IsGrounded())
                {
                    transform.GetComponent<Rigidbody>().velocity -= Vector3.up * extraDownwardForce * Time.deltaTime;
                }
            }
        }
        bool IsGrounded()
        {
            RaycastHit hitInfo;
            Color rayColor;
            float extraHieght = .01f;
            Physics.Raycast(transform.position, Vector3.down, out hitInfo, sphereCollider.bounds.extents.y + extraHieght);
            if (debug)
            {
                if (hitInfo.collider != null)
                {
                    rayColor = Color.green;
                }
                else
                {
                    rayColor = Color.red;
                }
                Debug.DrawRay(transform.position, Vector3.down * sphereCollider.bounds.extents.y, rayColor);
            }
            return (hitInfo.collider != null);
        }
        bool PlayerHit()
        {
            if (Input.touchCount > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.tag == "Player")
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public void IsDoubleTap()
        {
            if (PlayerHit())
            {
                print("PlayerHit");
            }
            if (count != 2)
            {
                timer = 0;
                count++;
            }
            if (count == 2)
            {
                if (timer < maxTouchTime)
                {
                    if (!PlayerHit())
                    {
                        gameObject.SetActive(false);
                    }
                }
            }

        }
    }

}
