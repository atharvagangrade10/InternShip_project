using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedBall
{
    public class tutorialManager : MonoBehaviour
    {
        int count = 0;
        public HudManager hudManager;
        public GameObject continueButton;
        public GameObject skipButton;
        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
            hudManager.disableAll();
            hudManager.setAlphaLeft();
            hudManager.enableLeft();

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnClickContinue()
        {
            switch (count)
            {
                case 0:
                    hudManager.disableLeft();
                    hudManager.resetAlphaLeft();
                    hudManager.setAlphaRight();
                    hudManager.enableRight();
                    count++;
                    break;
                case 1:
                    hudManager.disableRight();
                    hudManager.resetAlphaRight();
                    hudManager.setAlphaDisappear();
                    hudManager.enableDisappear();
                    count++;
                    break;
                case 2:
                    hudManager.disableDisappear();
                    hudManager.resetAlphaDisappear();
                    hudManager.enableJump();
                    count++;
                    break;
                case 3:
                    hudManager.pause.interactable = true;
                    hudManager.disableJump();
                    count = 0;
                    skipButton.SetActive(false);
                    continueButton.SetActive(false);
                    Time.timeScale = 1;

                    break;

                default:
                    break;
            }
        }
        public void OnClickSkip()
        {
            hudManager.disableAll();
            hudManager.resetAlphaDisappear();
            hudManager.resetAlphaLeft();
            hudManager.resetAlphaRight();
            hudManager.pause.interactable = true;
            skipButton.SetActive(false);
            continueButton.SetActive(false);
            
            Time.timeScale = 1;
        }
    }

}

