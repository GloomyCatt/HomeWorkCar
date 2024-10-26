using UnityEngine;

namespace Car
{
    public class Lights : MonoBehaviour
    {
        [SerializeField]
        private GameObject tailLights;
        [SerializeField]
        private GameObject frontLights;
        [SerializeField]
        private Material tailLightsMaterial;
        [SerializeField]
        private Material frontLightsMaterial;

        private void Update()
        {
            TurnOnLights(Input.GetAxis("Vertical") >= 0, frontLights, frontLightsMaterial);
            TurnOnLights(Input.GetAxis("Vertical") < 0, tailLights, tailLightsMaterial);
        }

        public void TurnOnLights(bool state, GameObject lightsObject, Material lightsMaterial)
        {
            lightsObject.SetActive(state);
            if (state)
            {
                lightsMaterial.EnableKeyword("_EMISSION");
            }
            else
            {
                lightsMaterial.DisableKeyword("_EMISSION");
            }

        }
    }
}