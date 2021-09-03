using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<!--
/// PieChartTest.cs
/// 
/// Project:  TirUtilities
///        
/// Author :  Devon Wilson
/// Created:  July 26, 2021
/// Updated:  July 26, 2021
/// -->
/// <summary>
///
/// </summary>
public class PieChartTest : MonoBehaviour
{
    #region Data Structures

    #endregion

    #region Inspector Fields

    [SerializeField] private List <(string, string)> _timePairs;
    [SerializeField] private List<float> _values;
    [SerializeField] private List<Color> _wedgeColors;
    [SerializeField] private GameObject _wedgePrefab;

    [SerializeField] private List<Image> _wedges = new List<Image>();

    #endregion

    #region Private Fields

    private System.TimeSpan _timeSpan = new System.TimeSpan(24, 0, 0);
    private List<System.TimeSpan> _timeSpans = new List<System.TimeSpan>();

    #endregion

    #region Events & Signals

    #endregion

    #region Unity Messages

    private void Start() => MakeChart();

    private void Update() => UpdateChart();

    #endregion

    #region Private Methods

    private void MakeChart()
    {
        string sleepStart = "00:00";
        string sleepEnd = "08:00";

        string morningStart = "08:00";
        string morningEnd = "10:00";

        string workStart = "10:00";
        string workEnd = "18:00";

        string eveningStart = "18:00";
        string eveningEnd = "20:00";

        string restStart = "20:00";
        string restEnd = "23:59";

        System.TimeSpan sleep = System.DateTime.Parse(sleepEnd).Subtract(System.DateTime.Parse(sleepStart));
        System.TimeSpan morning = System.DateTime.Parse(morningEnd).Subtract(System.DateTime.Parse(morningStart));
        System.TimeSpan work = System.DateTime.Parse(workEnd).Subtract(System.DateTime.Parse(workStart));
        System.TimeSpan evening = System.DateTime.Parse(eveningEnd).Subtract(System.DateTime.Parse(eveningStart));
        System.TimeSpan rest = System.DateTime.Parse(restEnd).Subtract(System.DateTime.Parse(restStart));

        _timeSpans.Add(sleep);
        _timeSpans.Add(morning);
        _timeSpans.Add(work);
        _timeSpans.Add(evening);
        _timeSpans.Add(rest);
        
        for (int i = 0; i < _timeSpans.Count; i++)
        {
            Debug.Log(_timeSpans[i].TotalHours);
            var wedge = Instantiate(_wedgePrefab).GetComponent<Image>();
            wedge.transform.SetParent(transform, false);
            wedge.color = _wedgeColors[i];

            _wedges.Add(wedge);
        }
    }

    private void UpdateChart()
    {
        double total = 0.0f;
        _timeSpans.ForEach(i => total += i.TotalHours);

        var rotation = Vector3.zero;
        float zRotation = 0.0f;

        for (int i = 0; i < _timeSpans.Count; i++)
        {
            var wedge = _wedges[i];
            wedge.fillAmount = (float)(_timeSpans[i].TotalHours / total);
            rotation.z = zRotation;
            wedge.transform.rotation = Quaternion.Euler(rotation);
            zRotation -= wedge.fillAmount * 360.0f;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Properties

    #endregion

    #region Public Properties

    #endregion
}