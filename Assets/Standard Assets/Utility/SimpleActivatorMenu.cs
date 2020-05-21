using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

#pragma warning disable 618
namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        public GameObject[] objects;


        private int m_CurrentActiveObject;

        public Text CamSwitchButton { get; set; }

        private void OnEnable()
        {
            // active object starts from first in array
            m_CurrentActiveObject = 0;
            CamSwitchButton.text = objects[m_CurrentActiveObject].name;
        }


        public void NextCamera()
        {
            int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextactiveobject);
            }

            m_CurrentActiveObject = nextactiveobject;
            CamSwitchButton.text = objects[m_CurrentActiveObject].name;
        }
    }
}
