using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RedBall
{
    public class HudManager : MonoBehaviour
    {
        public Image left;
        public Image right;
        public GameObject disappear;
        public Image[] disappearRegion;

        public Text jump;
        public Text leftText;
        public Text rightText;
        public Text disappearText;

        private float darkLeftColor = 0.6f;
        private float darkRightColor = 0.6f;
        private float darkDisappearColor = 0.6f;

        public float currLeftColor;
        private float currRightColor;
        private float currDisappearColor;

        public GameObject pauseMenu;
        public Button pause;

        private void Awake()
        {
            currLeftColor = left.color.a;
            pauseMenu.SetActive(false);
            pause.interactable = false;
        }
        // Start is called before the first frame update
        void Start()
        {
            disappearRegion = disappear.transform.GetComponentsInChildren<Image>();
            currDisappearColor = disappearRegion[0].color.a;
            currRightColor = right.color.a;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        #region TutorialMethods
        public void setAlphaLeft()
        {
            var tempColor = left.color;
            tempColor.a = darkLeftColor;
            left.color = tempColor;
        }
        public void resetAlphaLeft()
        {
            var tempColor = left.color;
            tempColor.a = currLeftColor;
            left.color = tempColor;
        }
        public void setAlphaRight()
        {
            var tempColor = left.color;
            tempColor.a = darkRightColor;
            right.color = tempColor;
        }
        public void resetAlphaRight()
        {
            var tempColor = left.color;
            tempColor.a = currRightColor;
            right.color = tempColor;
        }
        public void setAlphaDisappear()
        {
            var tempColor = disappearRegion[0].color;
            tempColor.a = darkDisappearColor;
            for (int i = 0; i < disappearRegion.Length; i++)
            {
                disappearRegion[i].color = tempColor;
            }
        }
        public void resetAlphaDisappear()
        {
            var tempColor = disappearRegion[0].color;
            tempColor.a = currDisappearColor;
            for (int i = 0; i < disappearRegion.Length; i++)
            {
                disappearRegion[i].color = tempColor;
            }
        }
        public void enableLeft()
        {
            leftText.gameObject.SetActive(true);
        }
        public void enableRight()
        {
            rightText.gameObject.SetActive(true);

        }
        public void enableJump()
        {
            jump.gameObject.SetActive(true);
        }
        public void enableDisappear()
        {
            disappearText.gameObject.SetActive(true);
        }


        public void disableLeft()
        {
            leftText.gameObject.SetActive(false);
        }
        public void disableRight()
        {
            rightText.gameObject.SetActive(false);

        }
        public void disableJump()
        {
            jump.gameObject.SetActive(false);
        }
        public void disableDisappear()
        {
            disappearText.gameObject.SetActive(false);
        }

        public void disableAll()
        {
            disableLeft();
            disableJump();
            disableRight();
            disableDisappear();
        }
        #endregion

        #region PauseMethods
        public void OnClickContinue()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        public void OnClickPause()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        public void OnclickRetry()
        {
            SceneManager.LoadScene(SceneName.Level.ToString());
        }
        public void OnclickExit()
        {
            SceneManager.LoadScene(SceneName.MainMenu.ToString());
        }    
        #endregion
    }
}
