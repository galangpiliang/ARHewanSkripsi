using UnityEngine;
using System.Collections;
using System.IO;

public class NativeShareScript : MonoBehaviour {
    public GameObject CanvasShareObj;

    private bool isProcessing = false;
    private bool isFocus = false;

    public void ShareBtnPress()
    {
        if (!isProcessing)
        {
            CanvasShareObj.SetActive(true);
            StartCoroutine(ShareScreenshot());
        }
    }

    public void openDownload(){
        Application.OpenURL("https://drive.google.com/open?id=1kTO4QB-x8HMDFtqMvu902HA91an9gQ-f");
    }

    IEnumerator ShareScreenshot()
    {
        isProcessing = true;

        yield return new WaitForEndOfFrame();

        // Application.CaptureScreenshot("screenshot.png", 2);
        string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");
		ScreenCapture.CaptureScreenshot("screenshot.png",2);

        yield return new WaitForSecondsRealtime(0.3f);

        if (!Application.isEditor)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
                uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                "Ayo ikutan main sama gua? link : https://play.google.com/store/apps/details?id=com.binaryworkssystems.pic");
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);

            yield return new WaitForSecondsRealtime(1);
        }

        yield return new WaitUntil(() => isFocus);
        CanvasShareObj.SetActive(false);
        isProcessing = false;
    }

    private void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }
}
