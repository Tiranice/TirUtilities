using System.Collections;
using UnityEngine;

namespace TirUtilities.LevelManagment.Experimental
{
    using TirUtilities.Extensions;
    using TirUtilities.Signals;
    ///<!--
    /// LoadingScreen.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 15, 2021
    /// Updated:  July 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingScreen : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField] private GameObject _loadingScreenPanel;
        [SerializeField] private CanvasGroup _canvasGroup;

        #endregion

        #region Events & Signals

        [SerializeField] private Signal _levelLoadCompleteSignal;

        #endregion

        #region Unity Messages

        private void Start()
        {
            if (_canvasGroup.IsNull())
                TryGetComponent(out _canvasGroup);
        }

        #endregion

        #region Private Methods

        private IEnumerator FadeLoadingScreen(float targetAlpha, float duration)
        {
            float startAlpha = _canvasGroup.alpha;
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                _canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _canvasGroup.alpha = targetAlpha;
        }

        #endregion

        #region Public Methods

        public IEnumerator Show(IEnumerator callbackCoroutine)
        {
            _loadingScreenPanel.SetActive(true);
            yield return StartCoroutine(FadeLoadingScreen(targetAlpha: 1, duration: 0.5f));
            yield return StartCoroutine(callbackCoroutine);
        }

        public IEnumerator Hide()
        {
            yield return StartCoroutine(FadeLoadingScreen(targetAlpha: 0, duration: 0.5f));
            _loadingScreenPanel.SetActive(false);
        }

        public IEnumerator Hide(IEnumerator callbackCoroutine)
        {
            yield return StartCoroutine(FadeLoadingScreen(targetAlpha: 0, duration: 0.5f));
            yield return StartCoroutine(callbackCoroutine);
            _loadingScreenPanel.SetActive(false);
        }

        #endregion
    }
}