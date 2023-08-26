using System.Collections;
using System.Collections.Generic;

using System;
public class TileSand 
{
    // Start is called before the first frame update
    public int IdTileSand;

    public int SpotX;
    public int SpotY;
    private Action<int> _SelectPathIdPlayer;
    void Start()
    {
        
    }
    public void SetActionFunction(Action<int> SelectPathIdPlayer) {
        _SelectPathIdPlayer = SelectPathIdPlayer;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
     
        if (_SelectPathIdPlayer != null)
        {
            
            _SelectPathIdPlayer(IdTileSand);
        }
    }
}
