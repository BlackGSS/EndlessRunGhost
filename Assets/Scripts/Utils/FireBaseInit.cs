
using UnityEngine;
using Firebase.Extensions;
using Firebase.Crashlytics;
using Firebase.Analytics;

public class FireBaseInit : MonoBehaviour
{
    Firebase.FirebaseApp app;
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;
                Crashlytics.ReportUncaughtExceptionsAsFatal = true;
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

                Debug.Log(app.Name);
                
				FirebaseAnalytics.LogEvent("App Initialized");

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void CrashMeButton()
    {
        throw new System.Exception("Test Crash Ignore");
    }
}
