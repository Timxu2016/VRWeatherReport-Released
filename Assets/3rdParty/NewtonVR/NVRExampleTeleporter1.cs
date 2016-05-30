using UnityEngine;
using System.Collections;

namespace NewtonVR.Example
{
    public class NVRExampleTeleporter1 : MonoBehaviour
    {
        public Color lineColor;
        public float lineWidth = 0.02f;
		//public GameObject reachableArea;
		public GameObject destinationPrefab;
		public Transform resetPosition;

        private LineRenderer line;
        private NVRHand hand;
		private Renderer[] rd;

        private void Awake()
        {
			line = this.GetComponent<LineRenderer>();
            hand = this.GetComponent<NVRHand>();
			/*
			rd = reachableArea.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in rd)
				renderer.enabled = false;
			*/

            if (line == null)
            {
                line = this.gameObject.AddComponent<LineRenderer>();
            }

            if (line.sharedMaterial == null)
            {
                line.material = new Material(Shader.Find("Unlit/Color"));
                line.material.SetColor("_Color", lineColor);
                line.SetColors(lineColor, lineColor);
            }

            line.useWorldSpace = true;
        }

		void Update()
		{
			var deviceIndex = (int)GetComponent<SteamVR_TrackedObject> ().index;
			if (deviceIndex != -1 && SteamVR_Controller.Input (deviceIndex).GetPressDown (SteamVR_Controller.ButtonMask.ApplicationMenu)) 
			{
				ResetPosition ();
			}
		}

        void LateUpdate()
        {
            if (line.enabled == true)
            {
                line.material.SetColor("_Color", lineColor);
                line.SetColors(lineColor, lineColor);
                line.SetWidth(lineWidth, lineWidth);

                RaycastHit hitInfo;
                bool hit = Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 200);
                Vector3 endPoint;

                if (hit)
                {
                    endPoint = hitInfo.point;

					var deviceIndex = (int)GetComponent<SteamVR_TrackedObject> ().index;
					if (deviceIndex != -1 && SteamVR_Controller.Input (deviceIndex).GetPress(SteamVR_Controller.ButtonMask.Touchpad)) 
					{
						//show reachable aera or spots;show a sign to show destination;
						/*foreach (Renderer renderer in rd)
							renderer.enabled = true;
						*/
						destinationPrefab.transform.position = endPoint + new Vector3(0,0.01f,0);
						destinationPrefab.transform.eulerAngles = new Vector3 (90f,transform.eulerAngles.y,0);

					} 
					else if(SteamVR_Controller.Input (deviceIndex).GetPressUp (SteamVR_Controller.ButtonMask.Touchpad))
					{
						Vector3 offset = NVRPlayer.Instance.Head.transform.position - NVRPlayer.Instance.transform.position;
						offset.y = 0;

						NVRPlayer.Instance.transform.position = hitInfo.point - offset;
						/*foreach (Renderer renderer in rd)
							renderer.enabled = false;*/
						destinationPrefab.transform.position = new Vector3(1000f,-100f,1000f);

					}
                }
                else
                {
                    endPoint = this.transform.position + (this.transform.forward * 1000f);
                }

                line.SetPositions(new Vector3[] { this.transform.position, endPoint });
            }
        }

		public void ResetPosition()
		{
			NVRPlayer.Instance.transform.position = resetPosition.position;
		}
    }
}