namespace WebShop.Models.Data
{
    //public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseAlways<Db>

    public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Db>
    {
        protected override void Seed(Db context)
        {

        }
    }
}