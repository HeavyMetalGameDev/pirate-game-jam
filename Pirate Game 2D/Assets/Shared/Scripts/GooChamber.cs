using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooChamber : MonoBehaviour
{
    [SerializeField] Level _level;
    [SerializeField] Vector2Int _gooOffset;
    [SerializeField] Animator _anim;
    bool _hasReleased = false;

    public delegate void OnGooRelease();
    public static event OnGooRelease onGooRelease;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasReleased)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            int gpt = _level.GetGooPerTile();
            Vector2Int gooPos = new Vector2Int((int)(transform.position.x * gpt) + _gooOffset.x, (int)(transform.position.y * gpt) + _gooOffset.y);
            _level.gooController.WriteToGooTile(gooPos.x,gooPos.y,GridChannel.TYPE,(float)GridTileType.GOO_SPREADABLE);
            _level.gooController.WriteToGooTile(gooPos.x,gooPos.y,GridChannel.TEMP,127.0f);
            _level.gooController.SendTexToGPU();
            onGooRelease?.Invoke();
            _anim.SetTrigger("OnBreak");
            //gameObject.SetActive(false);
        }
    }
}
