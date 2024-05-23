using UnityEngine;

public class WebViewLauncher : MonoBehaviour
{
    public void OpenWebView(string url) {
        #if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", currentActivity, new AndroidJavaClass("com.DefaultCompany.WebViewTest.WebViewActivity"));
            intent.Call<AndroidJavaObject>("putExtra", "url", url);
            currentActivity.Call("startActivity", intent);
        }
        #else
        Debug.Log("WebView is only supported on Android.");
        #endif
    }
}
