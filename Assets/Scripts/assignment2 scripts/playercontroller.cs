using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedBall
{
    public class playercontroller : MonoBehaviourPun
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void modifyPosition(int count)
        {
            if (photonView.IsMine)
            {
                photonView.RPC("changePosition", RpcTarget.AllBuffered, count);
            }            
        }
        [PunRPC]
        void changePosition(int count)
        {
            transform.GetComponent<Rigidbody>().MovePosition(transform.position+new Vector3(count, 0, 0));
        }


    }
}

