using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 8 Min Loop Structure
// Min 1 = 11 breaths per minute - 0.18 breaths pm
// Min 2 = 10 breaths per minute - 0.16 breaths pm
// Min 3 = 9 breaths per minute - 0.16 breaths pm
// Min 4 = 8 - 0.15 breaths pm
// Min 5 = 7 - 0.13 breaths pm
// Min 6 = 6 - 0.11 breaths pm
// Min 7 = 6 breaths per minute - 0.1 breaths pm - once every 10 seconds
// Min 8 = 6 breaths per minute -

// 20 Min Code Structure
// Min 1 = 11 times per minute (0.18). TimeRepeater set to 31 for 3 min
// Min 2 = 11
// Min 3 = 11
// Min 4 = 10 (0.16) TimeRepeater set to 30 for 3 min
// Min 5 = 10
// Min 6 = 10
// Min 7 = 9 (0.16) TimeRepeater set to 27 for 3 min
// Min 8 = 9
// Min 9 = 9
// Min 10 = 8 (0.15) TimeRepeater set to 22 for 3 min
// Min 11 = 8
// Min 12 = 8
// Min 13 = 7 (0.13) TimeRepeater set to 20 for 3 min
// Min 14 = 7
// Min 15 = 7
// Min 16 = 6.11 (0.11) TimeRepeater set to 13 for 2 min
// Min 17 = 6.11
// Min 18 = 6 (0.10) TimeRepeater set to 18 for 3 min
// Min 19 = 6
// Min 20 = 6

public class main : MonoBehaviour {

  [SerializeField]
  private Button btn8min;
  [SerializeField]
  private Button btn20min;
  [SerializeField]
  private Button btnExit;

  [SerializeField]
  private GameObject buttons;

  [SerializeField]
  private GameObject canvas;
  [SerializeField]
  private GameObject leds;

  private float runtime;

  private bool started = false;
  private bool ended = false;
  private float nextActionTime = 0.0f;
  public float period = 1.0f;

  // Use this for initialization
  void Start () {
    Screen.sleepTimeout = SleepTimeout.NeverSleep;
    leds.SetActive (false);
  }

  // Update is called once per frame
  void Update () {
    if (started == true && ended == false) {
      runtime -= Time.deltaTime;

      if (runtime <= 0.0f) {
        ended = true;
        exitApp();
      } else if (Time.time > nextActionTime) {
        nextActionTime += period;
        var currentMinute = Mathf.Floor (runtime / 60) + 1;
        print (currentMinute);
      }
    }

    if (Input.GetKeyDown (KeyCode.Escape)) Application.Quit ();
  }

  public void run8Minutes () {
    runtime = (.25f * 60f);
    started = true;
    print ("runtime 8min, hide canvas");
    canvas.SetActive (false);
    leds.SetActive (true);

  }
  public void run20Minutes () {
    runtime = 20 * 60f;
    started = true;
    print ("runtime 20min, hide canvas");
    canvas.SetActive (false);
    leds.SetActive (true);
  }

  public void exitApp () {
    print ("exit App");
    Application.Quit ();
  }
}