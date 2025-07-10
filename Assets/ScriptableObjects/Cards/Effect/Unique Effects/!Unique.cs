//Parent for any card that functions uniquely from any other card
//May not be the best way to do things but we'll see
public class SpecialEffect : CardEffect
{
    //Welcome to the weird shit navigation hub. Enjoy your stay
    public enum SpecialPointer { }
    public SpecialPointer sp;

    public override void Enhance()
    {
        switch (sp)
        {
            //TODO: Call specific void depending on what unique effect is needed  
        }
    }

    #region Unused Voids
    public override void Apply(CharacterBody body)
    {
        throw new System.NotImplementedException();
    }
    #endregion


}
