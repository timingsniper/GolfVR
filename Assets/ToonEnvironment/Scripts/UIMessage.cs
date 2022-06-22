using UnityEngine;
using System.Collections;

public class UIMessage : MonoBehaviour 
{
	public GameObject MessageGO;

	void Awake()
	{
		MessageGO.SetActive(true);
	}

	public void OnLogoClick() 
	{
		Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:6807");
	}

	public void CloseMessage()
	{
		MessageGO.SetActive(false);
		Camera.main.GetComponent<FreeCamMouseLook>().active = true;
	}
}
