namespace ZedAngular.Model.Terra.scenario
{
    public class CreateNameHero
    {
        public string GetOfferNameHero()
        {
            /*
            var rand = new System.Random();
            //int num = (int)Math.floor(Math.random() * BattlePlanetModel.OfferNameHero_ar.length);
            int num = rand.Next(InitGlobalParams.OfferNameHero_ar.Length);
            */
            int num = 0;
            return InitGlobalParams.OfferNameHero_ar[num];
        }
    }
}
