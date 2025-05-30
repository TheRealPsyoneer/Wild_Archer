using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformPieceBuild : MonoBehaviour
{
    [SerializeField] float moveDistance;
    [SerializeField] float buildInterval;
    
    [SerializeField] List<GameObject> pieces;
    [SerializeField] List<ParticleSystem> smoke;

    public void StartBuilding()
    {
        gameObject.SetActive(true);
        StartCoroutine(BuildPlatform(buildInterval));
    }

    IEnumerator BuildPlatform(float buildDuration)
    {
        for (int i=0; i<pieces.Count; i++)
        {
            pieces[i].SetActive(true);
            pieces[i].transform.DOMoveY(pieces[i].transform.position.y - moveDistance, buildDuration).From().OnComplete(() => smoke[i].Play());
            yield return new WaitForSeconds(buildDuration);
        }
        
    }
}
