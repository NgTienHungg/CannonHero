using UnityEngine;

#region PlayerPrefs
/*
 * Coin: int
 * BestScor: int
 * OnMusic: int
 * OnSound: int
 * IdCharacter: int (selected)
 * IdPreview: int (shop)
 * CharacterCode: string (character owning)
*/
#endregion

public class GameManager : Singleton<GameManager>
{
    public DataCharacter dataCharacter;

    private new void Awake()
    {
        base.Awake();

        if (!PlayerPrefs.HasKey("CharacterCode"))
        {
            // tao du lieu ban dau cho Shop: 1 la so huu nhan vat, 0 la chua so huu nhan vat
            string newCode = "1";
            for (int i = 1; i < dataCharacter.list.Count; ++i)
                newCode += "0";

            PlayerPrefs.SetString("CharacterCode", newCode);
        }
    }
}
