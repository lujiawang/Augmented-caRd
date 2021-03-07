using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
	private AudioSource audio;
	public string People_0_link;
	public string People_1_link;
	string peopleName = "", link;

	private Button btn;

	void Start()
	{
		audio = this.gameObject.GetComponent<AudioSource>();
		btn = this.gameObject.GetComponent<Button>();
	}

    private void Update()
    {
		if (Infos.index == 0)
        {
			peopleName = "Luga";
			link = People_0_link;
		}
        else
        {
			peopleName = "Yuqi";
			link = People_1_link;
        }

		if (link == "" && this.gameObject.CompareTag("Link"))
			btn.interactable = false;
		else
			btn.interactable = true;
	}


    /*Hyperlink*/ //0-email, 1-linkedin, 2-Ins, 3-tweeter
    public void OpenLink()
    {
		Application.OpenURL(link);
    }



	/*Share*/
	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);

		new NativeShare().AddFile(filePath)
			.SetSubject(peopleName + "'s E-Card").SetText("Check this cool E-card made by Echo-AR!").Share();
			//.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
			

		// Share on WhatsApp only, if installed (Android only)
		//if( NativeShare.TargetExists( "com.whatsapp" ) )
		//	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
	}


	public void ShareOutside()
    {
		StartCoroutine(TakeScreenshotAndShare());
    }

	/*Save*/
	public void SaveToAlbum()
	{
		if (audio != null)
        {
			audio.Play();
        }

		ScreenCapture.CaptureScreenshot(peopleName + "_EProfile" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
		
	}


}
